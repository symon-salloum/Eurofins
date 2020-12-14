using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Exceptions
{
    public class GetEntityException : Exception
    {
        public GetEntityException() { }

        public GetEntityException(string message) : base(message) { }

        public GetEntityException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
