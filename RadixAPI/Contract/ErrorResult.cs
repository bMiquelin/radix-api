using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Contract
{
    public class ErrorData
    {
        public string Message { get; set; }
        public string Code { get; set; }
        public ErrorData InnerError { get; set; }
    }
    public class ErrorResult
    {
        public ErrorResult(string message)
        {
            this.Error = new ErrorData
            {
                Message = message
            };
        }
        public ErrorData Error { get; set; }
    }
}
