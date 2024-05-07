using SymphoSphereApp.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SymphoSphereApp.Abstraction
{
    public interface IBaseRepository<TEntity> where TEntity : BaseItem
    {
        Task Create(TEntity item);
        Task<TEntity> FindAsyncById(int id);
        Task<IEnumerable<TEntity>> GetAsync();


        //For Future
        Task<TEntity> FindAsyncById(int Id, params Expression<Func<TEntity, object>>[] includes);
        Task<IQueryable<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includes);

        //
        Task Remove(TEntity item);
        Task Update(TEntity item);
    }
}
