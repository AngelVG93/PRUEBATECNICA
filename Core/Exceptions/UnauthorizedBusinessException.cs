using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class UnauthorizedBusinessException : BaseException
    {
        public UnauthorizedBusinessException(LogException entityBaseException) : base(entityBaseException)
        {
        }
        public UnauthorizedBusinessException(string mesaage) : base(mesaage)
        {
        }
        public UnauthorizedBusinessException(LogException exception, string information) : base($"{exception.Message} : {information}")
        {
        }
    }
}
