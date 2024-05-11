using Microsoft.EntityFrameworkCore;
using SymphoSphereApp.Abstraction;
using SymphoSphereApp.DAL;
using SymphoSphereApp.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SymphoSphereApp.Repository
{
    internal class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseItem
    {
        AppDbContext _context;
        DbSet<TEntity> _dbSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        


        public async Task Create(TEntity item)
        {
            _dbSet.Add(item);
            await Save();
        }

        public async Task<TEntity> FindAsyncById(int id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TEntity> FindAsyncById(int Id, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<IQueryable<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public async Task Remove(TEntity item)
        {
            _dbSet.Remove(item);
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(TEntity item)
        {
                //_context.Entry(item).State = EntityState.Modified;
                _context.Update(item);
                await Save();
           
        }

    }
}
