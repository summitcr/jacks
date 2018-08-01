using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jacks.Services.Utils
{
    /// <summary>
    /// Clase para descentralizar el armado de las rutas a los recursos.
    /// </summary>
   public class URLHelper
    {
        private static URLHelper helper;
        private static URLHelper Helper
        {
            get
            {
                if (helper == null)
                {
                    helper = new URLHelper();

                }
                return helper;
            }
        
         }

        private string GetEndpoint() {

            try
            {
                //se obtiene la ruta del "root" de los endpoints. Desde el achivo app.config se crea un Key llamado "endpoint"
                //se puede modificar en caso de que cambie el root del endpoint.
                return ConfigurationManager.AppSettings["endpoint"];
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public  static string GetLogUrl()
        {
            try
            {
                string endpoint = Helper.GetEndpoint();
                //se crear la ruta completa para la obtener el recurso de logs 
                return endpoint +"/"+ "select_all_LOGS_operation";

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public static string PostLogUrl()
        {
            try
            {
                string endpoint = Helper.GetEndpoint();
                //se crear la ruta completa para insertar un recurso de log
                return endpoint + "/" + "_postinsert_logs_operation";

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}
