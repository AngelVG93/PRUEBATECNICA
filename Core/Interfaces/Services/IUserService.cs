using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IUserService : IBaseService<User>
    {
        Task<User> GetInfoServicePermiss(int id);    
    }
}
