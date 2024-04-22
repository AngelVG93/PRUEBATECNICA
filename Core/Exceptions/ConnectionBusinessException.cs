using Core.Entities;

namespace Core.Exceptions
{
    public class ConnectionBusinessException : BaseException
    {
        public ConnectionBusinessException(LogException entityBaseException) : base(entityBaseException)
        {
        }
    }
}
