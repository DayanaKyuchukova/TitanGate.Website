using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TitanGate.Website.Domain;

namespace TitanGate.Website.DAL.Abstract
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> filter = null);

        Task<TEntity> GetByIdAsync<TKey>(TKey id);

        Task CreateAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task SoftDeleteAsync<TDeletable>(TDeletable entity)
            where TDeletable : TEntity, IDeletable;
    }
}
