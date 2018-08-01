using Jacks.Models.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Jacks.Services.Utils
{
    public static class XmlConvert
    {
        //Método para serializar un objeto del tipo T a un objeto XML. En este proyecto no se utliza.
        public static string SerializeObject<T>(T dataObject)
        {
            if (dataObject == null)
            {
                return string.Empty;
            }
            try
            {
                using (StringWriter stringWriter = new System.IO.StringWriter())
                {
                    var serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(stringWriter, dataObject);
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        //Método para desserializar un objeto XML a un modelo del tipo T.
        public static T DeserializeObject<T>(string xml)
             where T : class
        {
            try
            {

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                //por alguna razón el tipo de objeto XML con el que se desarrollo esta prácatica daba errores a la hora 
                //deserelizarse. Por ese motivo decidí pasarlo primero a un objeto Json para luego deserizarlo.
                string jsonText = JsonConvert.SerializeXmlNode(doc);
                T rootObject = JsonConvert.DeserializeObject<T>(jsonText);

                return rootObject;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
