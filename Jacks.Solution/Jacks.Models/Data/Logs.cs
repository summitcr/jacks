using Jacks.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Jacks.Models.Data
{
    //estas clases trabajan como un módelo único en cojunto. Por eso el porqué se encuentran en el mismo archivo.
    //estas clases se utiliar para deserializar los logs obetenidos en el Get Request.
    public class LOG
    {
        public int recid { get; set; }
        public string Mensaje { get; set; }
        public string Fecha { get; set; }
    }

    public class LOGSCollection
    {
        public List<LOG> LOGS { get; set; }
    }

    public class RootObject
    {
        public LOGSCollection LOGSCollection { get; set; }
    }

 
}
