using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jacks.Interfaces.Services;
using Jacks.Models.Data;
using System.Net.Http;

using Jacks.Services.Utils;
using Newtonsoft.Json;

namespace Jacks.Services.LogServices
{
    /// <summary>
    /// Implementación de la capa de servicios. Se utliza un sabor del patrón "Facade" llamado Repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Service<T> : IService<T> where T: class
    {
        private HttpClient httpclient;
        private string url;
        public Service(string _url)
        {
            url = _url;
            httpclient = new HttpClient();
        }
        /// <summary>
        /// Se obtiene la información de la 
        /// </summary>
        /// <returns></returns>
        public async Task<T> Get()
        {
            try
            {
                //Se hace un Get resquest, génerico y asíncrono.
                var response = await httpclient.GetAsync(new Uri(url));

                if (response.IsSuccessStatusCode)
                {
                    //se lee el contenido de la respuesta.
                    string content = await response.Content.ReadAsStringAsync();
                    //se obtiene un modelo del tipo T del contenido de la respuesta. 
                    var desObject = XmlConvert.DeserializeObject<T>(content);
                    return desObject;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


            return null; ;
        }

      

        /// <summary>
        /// Metodo genérico para insertar la información del modelo tipo T.
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public async Task<Boolean> Post(T model)
          {
              try
              {
                //se serializa el modelo tipo T a un objeto Json.
                string json = JsonConvert.SerializeObject(model);
                //se asigna el tipo del contenido para el Post request. Este tipo es del tipo application/json
                using (var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json"))
                //se crea un recurso de la instancia HttpClient
                using (var client = new HttpClient())
                {
                    try
                    {
                        //Se hace el Post Request asíncrono y se obtiene el resultado
                        var response = client.PostAsync(url, stringContent).Result;
                        var result = await response.Content.ReadAsStringAsync();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }

               
                  return true;
              }
              catch (Exception ex)
              {

                  throw new Exception(ex.Message);
              }
          }


    }
}
