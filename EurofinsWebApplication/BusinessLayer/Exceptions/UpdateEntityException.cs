using System;

namespace BusinessLayer.Exceptions
{
    public class UpdateEntityException : Exception
    {
        public UpdateEntityException() { }

        public UpdateEntityException(string message) : base(message) { }

        public UpdateEntityException(string message, Exception innerException) : base(message, innerException) { }
    }
}
