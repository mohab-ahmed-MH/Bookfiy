using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiy.Core.Interfaces
{
    public interface IBaseRepositoty<T> where T : class
    {
        T GetById(int id);

        IEnumerable<T> GetAll();

        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(int id,T entity);
        T Delete(int id, T entity);

    }
}
