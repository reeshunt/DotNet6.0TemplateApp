using System;
using Microsoft.EntityFrameworkCore;
using Testing.BAL.Interfaces;
using Testing.DAL.Entities;
namespace Testing.BAL.Services
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
        //,IEntity
    {
        private readonly MachineTestContext _dbContext;
        public GenericRepository(MachineTestContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(int id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public Task<TEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

