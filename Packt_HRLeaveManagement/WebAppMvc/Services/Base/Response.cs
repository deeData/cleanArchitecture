using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMvc.Services.Base
{
    //response from the client
    public class Response<T>
    {
        public string Message { get; set; }
        public string ValidationErrors { get; set; }
        public bool Success { get; set; }
        //unknown object T (need to eventually specify)
        public T Data { get; set; }
    }
}
