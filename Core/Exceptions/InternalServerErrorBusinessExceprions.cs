using Core.Entities;

namespace Core.Exceptions
{
    public class InternalServerErrorBusinessExceprions : BaseException
    {
        public InternalServerErrorBusinessExceprions(LogException entityBaseException) : base(entityBaseException)
        {
        }
        public InternalServerErrorBusinessExceprions(string mesaage) : base(mesaage)
        {
        }
        public InternalServerErrorBusinessExceprions(LogException exception, string information) : base($"{exception.Message} : {information}")
        {
        }
    }
}
