using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class BaseException : Exception
    {
        public LogException ?exception { get; set; }
        public BaseException(LogException entityBaseException) : base(entityBaseException.Message)
        {
            this.exception = exception;
        }
        public BaseException(string ?mesaage) : base(mesaage)
        {
        }

        public BaseException(LogException exception, string information) : base($"{exception.Message} : {information}")
        {
            this.exception = exception;
        }
    }
}
