using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jacks.Models.Data;


namespace Jacks.Interfaces.Services
{
    /// <summary>
    /// Interface genérica implementar la capa de servicio.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IService<T> where T:class
    {

        Task<T> Get();
        Task<Boolean> Post(T log);

        
    }
}
