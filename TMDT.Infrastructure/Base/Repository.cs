using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMDT.Infrastructure.Models;

namespace TMDT.Infrastructure.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public readonly TMDTContext _dbContext;
        public Repository(IConfiguration config)
        {
            _dbContext = new TMDTContext(config);
        }
        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }
        public virtual async Task<List<TEntity>> GetCanChangeListAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetRecordByNoAsync(string no)
        {
            return await _dbContext.Set<TEntity>().FindAsync(no);
        }

        public async Task<TEntity> InsertNewAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
