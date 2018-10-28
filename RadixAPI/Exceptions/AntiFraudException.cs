using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Exceptions
{
    public class AntiFraudException : APIException
    {
        public AntiFraudException(string message) : base(message) {}
    }
}
