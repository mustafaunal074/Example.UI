using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Example.Core.DataAccess.Abstract
{
    public interface IBaseRepository<T>
    {
        Task<bool> Add(T Model);
        Task<bool> Update(T Model);
        Task<bool> Delete(T Model);
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<IList<T>> GetList(Expression<Func<T, bool>> filter = null);
    }
}
