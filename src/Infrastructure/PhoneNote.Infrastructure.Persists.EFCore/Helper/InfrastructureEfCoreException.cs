using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNote.Infrastructure.Persists.EFCore.Helper
{
    public class InfrastructureEfCoreException : Exception
    {

        public InfrastructureEfCoreException(string message, string argumentName) : base(message)
        {
            ArgumentName = argumentName;
        }
        public InfrastructureEfCoreException(string message) : base(message)
        {

        }
        public string ArgumentName { get; private set; }
    }
}
