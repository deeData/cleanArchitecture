using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebAppMvc.Contracts;

namespace WebAppMvc.Services.Base
{
    //every service to be able to do
    public class BaseHttpService
    {
        public readonly IClient _client;
        private readonly ILocalStorageService _localStorage;

        public BaseHttpService(IClient client, ILocalStorageService localStorageService)
        {
            _client = client;
            _localStorage = localStorageService;
        }

        //convert from ServiceCLient the ApiException to a customized Reponse
        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException ex)
        {
            //bad request
            if (ex.StatusCode == 400)
            {
                return new Response<Guid>() { Message = "Validation errors have occured.", ValidationErrors = ex.Response, Success = false };
            }
            else if (ex.StatusCode == 404)
            {
                return new Response<Guid>() { Message = "The requested item could not be found.", Success = false };
            }
            else
            {
                return new Response<Guid>() { Message = "Something went wrong, please try again", Success = false };
            }
        }

        //get token to send with http request
        protected void AddBearerTokec() 
        {
            if (_localStorage.Exists("token"))
                _client.HttpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _localStorage.GetStorageValue<string>("token"));
        }
    }
}
