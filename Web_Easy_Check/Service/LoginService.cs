using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Easy_Check.Models;

namespace Web_Easy_Check.Service
{
    public class LoginService
    {
        const string baseUrl = "https://frozen-waters-52896.herokuapp.com/";

        public Usuario loginRequest(Login login)
        {
            try
            {
                var client = new RestClient(baseUrl);
                var request = new RestRequest("login", Method.POST);
                request.AddParameter("application/json", JsonConvert.SerializeObject(login), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                var content = response.Content;
                return JsonConvert.DeserializeObject<Usuario>(content);
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}