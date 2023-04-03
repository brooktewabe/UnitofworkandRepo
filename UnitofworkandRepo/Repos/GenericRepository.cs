using Microsoft.EntityFrameworkCore;
using UnitofworkandRepo.Interface;
using UnitofworkandRepo.Models;

namespace UnitofworkandRepo.Repos
{
    public class GenericRepository<T> : iGenericRespoitory<T> where T : class
    {
        protected TestContext dbContext;
        internal DbSet<T> DbSet { get; set; }

        public GenericRepository(TestContext test)
        {
            this.dbContext = test;
            this.DbSet = this.dbContext.Set<T>();
        }

        public virtual Task<bool> AddEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<List<T>> GetAllAsync()
        {
            return this.DbSet.ToListAsync();
        }

        public virtual Task<T> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> UpdateEntity(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
