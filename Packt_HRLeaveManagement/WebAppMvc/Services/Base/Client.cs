using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebAppMvc.Services.Base
{
    //entends class using partial
    public partial class Client : IClient
    {
        //allows to interact with client
        //will pull in private prop _httpClient from ServiceClient.cs- needs to be in same namespace
        public HttpClient HttpClient 
        {
            get 
            {
                return _httpClient;
            }
        }
    }
}
