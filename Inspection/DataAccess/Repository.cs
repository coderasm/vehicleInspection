using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dommel;

namespace Inspection.DataAccess
{
    public class Repository<T> : BaseRepository<T> where T : class
    {
        public async Task<IEnumerable<T>> getAll()
        {
            using (var connection = await ConnectionFactory.getOpenConnection())
            {
                return connection.GetAll<T>();
            }
        }

        public async Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> query)
        {
            using (var connection = await ConnectionFactory.getOpenConnection())
            {
                return connection.Select(query);
            }
        }

        public async Task<T> getById(int id)
        {
            using (var connection = await ConnectionFactory.getOpenConnection())
            {
                return connection.Get<T>(id);
            }
        }

        public async Task<bool> update(T poco)
        {
            using (var connection = await ConnectionFactory.getOpenConnection())
            {
                return connection.Update(poco);
            }
        }

        public async Task<int> insert(T poco)
        {
            using (var connection = await ConnectionFactory.getOpenConnection())
            {
                return (int)connection.Insert(poco);
            }
        }

        public async Task<bool> delete(T poco)
        {
            using (var connection = await ConnectionFactory.getOpenConnection())
            {
                return connection.Delete(poco);
            }
        }
    }
}
