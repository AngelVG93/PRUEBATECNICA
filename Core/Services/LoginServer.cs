using Core.DTOs;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class LoginServer : BaseService<Login>, ILoginServer
    {
        public LoginServer(IAdminInterfaces adminInterfaces) : base(adminInterfaces)
        {
        }
        public async Task<Login> PostLogin(string usernumber, string password)
        {
            Login login = new Login();
            var userLogin = await _adminInterfaces.userRepository.GetUserLogin(usernumber,_adminInterfaces.utilsFunctionsRepository.DecodeMd5(password));
            if(userLogin != null)
            {
                login.userName = userLogin.Name;
                login.lastName = userLogin.LastName;
                login.idUser = userLogin.id;

                login.bearerToken = _adminInterfaces.utilsFunctionsRepository.GenerateTokenJWT(userLogin);
            }
            else
            {
                LogException exception = new LogException();
                exception.Name = "Usuario";
                exception.Message = "Usuario no encontrado";
                exception.DateTimeException = DateTime.Now;
                throw new BadRequestBusinessException(exception);
            }
            return login;
        }
        public Task<bool> Delete(Login entity)
        {
            throw new NotImplementedException();
        }

        public Task<Login> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Login>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Login> Post(Login entity)
        {
            throw new NotImplementedException();
        }

        public Task<Login> Put(Login entity)
        {
            throw new NotImplementedException();
        }
    }
}
