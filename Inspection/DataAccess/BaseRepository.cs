using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Inspection.DataAccess
{
    public interface BaseRepository<T>
    {
        Task<IEnumerable<T>> getAll();

        Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> query);

        Task<T> getById(int id);

        Task<bool> update(T poco);

        Task<int> insert(T poco);

        Task<bool> delete(T poco);
    }
}
