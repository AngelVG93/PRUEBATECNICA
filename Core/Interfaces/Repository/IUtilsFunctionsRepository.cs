using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repository
{
    public interface IUtilsFunctionsRepository
    {
        string DecodeMd5(string StringToConvert);
        string GenerateTokenJWT(User user);
        int GetIdUserToken(string Token);
    }
}
