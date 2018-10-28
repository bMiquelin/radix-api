using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Exceptions
{
    public class ProviderException : APIException
    {
        public ProviderException(string message) : base(message) {}
    }
}
