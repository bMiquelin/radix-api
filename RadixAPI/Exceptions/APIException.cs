using RadixAPI.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Exceptions
{
    public abstract class APIException : Exception
    {
        protected APIException(string message) : base(message) {}
        public ErrorResult ToErrorResult() => new ErrorResult(this.Message);
    }
}
