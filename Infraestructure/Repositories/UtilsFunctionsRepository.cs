using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Infraestructure.Repositories
{
    public class UtilsFunctionsRepository : IUtilsFunctionsRepository
    {
        private IConfiguration? _configuration;
        public UtilsFunctionsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string DecodeMd5(string StringToConvert)
        {
            try
            {
                byte[] BtClearBytes;
                BtClearBytes = new UnicodeEncoding().GetBytes(StringToConvert);
                byte[] BtHashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(BtClearBytes);
                return BitConverter.ToString(BtHashedBytes);
            }
            catch (Exception)
            {
                UnauthorizedBusinessException ex = new UnauthorizedBusinessException("Error encript MD5 in UtilsFunctionsRepository");
                throw ex;
            }
        }

        public string GenerateTokenJWT(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.id.ToString()));
            claims.AddClaim(new Claim("idUser", user.id.ToString()));
            claims.AddClaim(new Claim("nameUser", user.Name));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.Now.AddDays(30),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(createdToken);
        }

        public int GetIdUserToken(string Token)
        {
            if (Token != null)
            {
                try
                {
                    string formatToken = Token.Remove(0, 7);
                    SecurityToken securityToken = null;
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"]));

                    TokenValidationParameters validationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = key,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                         ValidAudience = _configuration["Jwt:Audience"],
                         ValidIssuer = _configuration["Jwt:Issuer"],
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        LifetimeValidator = this.Lifetimevalidator

                    };
                    var tokendata = tokenHandler.ValidateToken(formatToken, validationParameters, out securityToken);
                    var arrayDataToken = tokendata.Identities.Select(x => x.Claims).ToArray();
                    foreach (var item in arrayDataToken)
                    {
                        foreach (var item1 in item)
                        {
                            if (item1.Type == "idUser")
                            {
                                return Int32.Parse(item1.Value);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    LogException logException = new LogException();
                    logException.Message = $"Error valid token : {e.Message}";
                    logException.Name = "Error valid token";

                    UnauthorizedBusinessException ex = new UnauthorizedBusinessException(logException);
                    throw ex;
                }

            }
            return 0;
        }
        public bool Lifetimevalidator(DateTime? notBefore,
                              DateTime? expires,
                              SecurityToken securityToken,
                              TokenValidationParameters tokenValidationParameters)
        {
            var valid = false;
            if (expires.HasValue && DateTime.UtcNow < expires)
            {
                valid = true;
            }
            return valid;
        }
    }
}
