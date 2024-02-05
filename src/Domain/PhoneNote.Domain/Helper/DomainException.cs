using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNote.Domain.Helper
{
    public class DomainException:Exception
    {

        public DomainException(string message, string argumentName) : base(message)
        {
            ArgumentName = argumentName;
        }
        public DomainException(string message, string argumentName, ExceptionType exceptionType) : base(message)
        {
            ArgumentName = argumentName;
            ExceptionType = exceptionType;
        }
        public DomainException(string message) : base(message)
        {

        }
        public DomainException(string message, ExceptionType exceptionType) : base(message)
        {
            ExceptionType = exceptionType;
        }
        public string ArgumentName { get; private set; }
        public ExceptionType ExceptionType { get; private set; }
    }
}
