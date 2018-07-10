using Newtonsoft.Json;
using RestSharp;
using System;
using Web_Easy_Check.Models;
using Web_Easy_Check.Util;

namespace Web_Easy_Check.Service
{
    public class Request
    {
        const string baseUrl = "https://frozen-waters-52896.herokuapp.com/";
        
        public Folha PostFolha(RequestValuesFolha requestValuesFolha)
        {
            try
            {
                var _getSessionUsuario = new GetSessionUsuario();
                if (_getSessionUsuario.IsUsarioLogado())
                {
                    var id = _getSessionUsuario.GetUsuario().Id;
                    var client = new RestClient(baseUrl);
                    var request = new RestRequest("folhas/" + id, Method.POST);
                    request.AddParameter("application/json", JsonConvert.SerializeObject(requestValuesFolha), ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);
                    var content = response.Content;
                    return JsonConvert.DeserializeObject<Folha>(content);
                }
                throw new Exception("Usuario deslogado");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Usuario GetUsuarioParaImg()
        {
            var _getSessionUsuario = new GetSessionUsuario();
            return _getSessionUsuario.GetUsuario();
        }

        public bool IsLogado()
        {
            var _getSessionUsuario = new GetSessionUsuario();
            return _getSessionUsuario.IsUsarioLogado();
        }

        public Ponto PostPonto(RequestValuesPonto requestValuesPonto)
        {
            try
            {
                var _getSessionUsuario = new GetSessionUsuario();
                if (_getSessionUsuario.IsUsarioLogado())
                {
                    var id = _getSessionUsuario.GetUsuario().Id;
                    var client = new RestClient(baseUrl);
                    var request = new RestRequest("batidas/" + id, Method.POST);
                    request.AddParameter("application/json", JsonConvert.SerializeObject(requestValuesPonto), ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);
                    var content = response.Content;
                    return JsonConvert.DeserializeObject<Ponto>(content);
                }
                throw new Exception("Usuario deslogado");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}