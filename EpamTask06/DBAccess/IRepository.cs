using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06
{

    /// <summary>
    /// Interface for implementation of IRepository Pattern
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetCollection();
        void Create(T obj);
        T Read(int id);
        void Update(T obj);
        void Delete(int id);
    }
}
