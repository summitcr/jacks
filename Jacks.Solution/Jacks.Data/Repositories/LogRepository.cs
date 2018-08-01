using Jacks.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jacks.Models.Data;

namespace Jacks.Data.Repositories
{
    public class LogRepository : IRepository<Logs>
    {
        IService
        public List<Logs> Get()
        {

            try
            {


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            };
        }

        public List<Logs> Get(logcallback func)
        {
            throw new NotImplementedException();
        }
    }
}
