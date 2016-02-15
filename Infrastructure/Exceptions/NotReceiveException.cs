using System;

namespace Infrastructure.Exceptions
{
    public sealed class NotReceiveException : ApplicationException
    {
        public NotReceiveException()
        {

        }

        public NotReceiveException(string message)
            : base(message)
        {

        }

        public NotReceiveException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
