using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jacks.UI
{
    public class App
    {
        /// <summary>
        /// Método que inicia el flujo desde la app
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var logmanager = new LogManager();
            logmanager.Init();
        }
    }
}
