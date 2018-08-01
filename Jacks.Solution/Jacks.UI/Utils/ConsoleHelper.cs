using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jacks.Models.Data;
using System.Data;
using MarkdownLog;

namespace Jacks.UI.Utils
{
    public class ConsoleHelper
    {
        /// <summary>
        /// metodo que se utliza para pintar una tabla en la consola. Para esto se utilizó el Nugget MarkdownLog
        /// </summary>
        /// <param name="models"></param>
        public void PrintLog(List<LOG> models) {
                Console.Clear();

            try
            {
                //Este "extention method" es el que toma el arreglo de datos y los convierte en una tabla.
                Console.Write( models.ToArray().ToMarkdownTable());
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// método que genera un mensaje al azar.
        /// </summary>
        /// <returns></returns>
        public static  string RandomMessage()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
      
    }
}
