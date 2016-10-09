using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCS.Services
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        void Create(T entity);
    }
}
