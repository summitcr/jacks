using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jacks.Interfaces.Services;
using Jacks.Services.LogServices;
using Jacks.Models.Data;
using Jacks.UI.Utils;
using System.Threading;
using Jacks.Services.Utils;

namespace Jacks.UI
{
    public class LogManager
    {

       

       
        /// <summary>
        /// inicial el flujo de trabajo 
        /// </summary>
        public void Init()
        {
            Reader();
        }
        /// <summary>
        /// obtiene el último rcid almacenado
        /// </summary>
        /// <returns></returns>
        private int GetLatestRCID()
        {
            try
            {
                IService<RootObject> logs = new Service<RootObject>(URLHelper.GetLogUrl());
                var data = logs.Get();
                int rcid =  (data.Result.LOGSCollection.LOGS.Any()) ? data.Result.LOGSCollection.LOGS.OrderByDescending(x => x.recid).First().recid : 1;
                rcid++;
                return rcid;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Método que inserta datos aleatorio para su consecuente lectura.
        /// </summary>
        private void Poster()
        {
            try
            {
               
                //se crea una instancia de IService, en en su implentación concreta Service.
                IService<PostLog> logs = new Service<PostLog>(URLHelper.PostLogUrl());
                 logs.Post
                    (
                     //se crea una instancia del modelo PostLog que será envíado al api de inserción en el Post Request.
                      new PostLog()
                      {
                          
                          _postinsert_logs_operation = new PostinsertLogsOperation()
                          {
                              Fecha = DateTime.Now.ToString("yyyy-MM-dd"),
                              recid = GetLatestRCID(),
                              Mensaje = ConsoleHelper.RandomMessage()
                          }
                      }
               );

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }
        /// <summary>
        /// metodo que ejecuta el Get request. 
        /// </summary>
        private void Reader()
        {
            try
            {
                ///se ejecutra una Tarea asincrónica.
                Task.Run(async () =>
                {
                    while (true)
                    {
                        //se llama el método para crear un registro nuevo.
                        Poster();
                        //se detiene el hilo 2 segundos.
                        await Task.Delay(2000);

                        //se crea una instancia de IService, en en su implentación concreta Service.
                        IService<RootObject> logs = new Service<RootObject>(URLHelper.GetLogUrl());
                        //se obtienen los datos de logs desde el servidor de apis.
                        var data = logs.Get();
                        // se ordena la información de menor a mayor usando como criterio recid.
                        var ordereddata = data.Result.LOGSCollection.LOGS.OrderBy(x => x.recid);
                        Print(ordereddata.ToList());

                        //se de tiene el hilo un segundo antes de la siguiente ejecución del proceso.
                        await Task.Delay(1000);
                    }
                }).Wait();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }
        private void Print(List<LOG> models)
        {
            if (!models.Any())
                return;

            var helper = new ConsoleHelper();
            helper.PrintLog(models);

        }
    }
}
