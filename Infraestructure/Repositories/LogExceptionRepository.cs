using Core.Entities;
using Core.Interfaces.Repository;
using Persistence.ContextDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class LogExceptionRepository : BaseRepository<LogException>, ILogExceptionRepository
    {
        public LogExceptionRepository(pruebatecnicaDbContext contex) : base(contex)
        {
        }
    }
}
