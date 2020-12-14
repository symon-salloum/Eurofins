using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Exceptions
{
    public class DeleteEntityException : Exception
    {
        public DeleteEntityException() { }

        public DeleteEntityException(string message) : base(message) { }

        public DeleteEntityException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
