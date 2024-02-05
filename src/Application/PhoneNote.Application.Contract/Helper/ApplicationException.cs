using PhoneNote.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNote.Application.Contract.Helper
{
    public class ApplicationException : Exception
    {

        public ApplicationException(string message, string argumentName) : base(message)
        {
            ArgumentName = argumentName;
        }
        public ApplicationException(string message, string argumentName, ExceptionType exceptionType) : base(message)
        {
            ArgumentName = argumentName;
            ExceptionType = exceptionType;
        }
        public ApplicationException(string message) : base(message)
        {

        }
        public ApplicationException(string message,ExceptionType exceptionType) : base(message)
        {
            ExceptionType = exceptionType;
        }
        public string ArgumentName { get; private set; }
        public ExceptionType ExceptionType { get; private set; }
    }
}
