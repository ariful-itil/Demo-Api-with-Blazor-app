using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewModels
{

    public class Responses
    {
        public bool IsSuccess { get; set; }
        public string Success { get; set; }
        public string Message { get; set; }
        public string ReturnCode { get; set; }
    }

    public enum ResponseStatus
    {
        Success,
        Failed,
        Found,
        NotFound,
        UnAuthorized
    }
}
