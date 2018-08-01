using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jacks.Models.Data
{
  
    //estas clases se utilizar en conjunto como un módelo único(por eso se encuentra en el mismo archivo) para 
    //la creación de un objeto Json en el post request de los log.
    public class PostinsertLogsOperation
    {
        public int recid { get; set; }
        public string Mensaje { get; set; }
        public string Fecha { get; set; }
    }

    public class PostLog
    {
        public PostinsertLogsOperation _postinsert_logs_operation { get; set; }
    }
}
