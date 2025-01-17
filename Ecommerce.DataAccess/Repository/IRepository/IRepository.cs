using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //T- category or any other model
        IEnumerable<T> GetAll();
        //if only one
        T Get(Expression<Func<T, bool>> filter);
        //create,remove etc
        void Add(T entity);
        
        void Remove(T entity);  
        void RemoveRange(IEnumerable<T> entity);

    }
}
