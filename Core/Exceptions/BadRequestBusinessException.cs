

using Core.Entities;

namespace Core.Exceptions
{
    public class BadRequestBusinessException : BaseException
    {
        public BadRequestBusinessException(LogException entityBaseException) : base(entityBaseException)
        {
        }
        public BadRequestBusinessException(LogException exception, string information) : base($"{exception.Message} : {information}")
        {
        }
    }
}
