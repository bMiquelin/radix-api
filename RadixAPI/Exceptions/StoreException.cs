using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Exceptions
{
    public class StoreException : APIException
    {
        public StoreException(string message) : base(message) {}
    }
}
