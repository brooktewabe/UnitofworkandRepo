using Microsoft.EntityFrameworkCore;
using UnitofworkandRepo.Interface;
using UnitofworkandRepo.Models;

namespace UnitofworkandRepo.Repos
{
    public class MytblRepos : GenericRepository<Mytbl>, iMytblRepository
    {
        public MytblRepos(TestContext test) : base(test)
        {
        }
        public override Task<List<Mytbl>> GetAllAsync()
        {
            return base.GetAllAsync();
            //dapper
            //return (List<Mytbl>)await _db.QueryAsync<Mytbl>("SELECT * FROM Mytbl");
        }
        public override async Task<Mytbl> GetAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(item => item.Id == id);
        }
        public override async Task<bool> AddEntity(Mytbl entity)
        {
            try
            {
                await DbSet.AddAsync(entity);
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public override async Task<bool>UpdateEntity(Mytbl entity)
        {
            try
            {
                var existdata=await DbSet.FirstOrDefaultAsync(item => item.Id == entity.Id);
                if (existdata != null)
                {
                    existdata.Id = entity.Id;
                    existdata.Name = entity.Name;
                    existdata.Greet=entity.Greet;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public override async Task<bool> DeleteEntity(int id)
        {
            try
            {
                var existdata = await DbSet.FirstOrDefaultAsync(item => item.Id == id);
                if (existdata != null)
                {
                    DbSet.Remove(existdata);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    //example func using dapper instead of EF core 
    //include system.Data,dapper and add private var like _db,db
    //add service IDbConnection in program.cs and declare private readonly  _db, db;
    //public MytblRepos(TestContext test, IDbConnection db) : base(test)
    //{
    //    this.db = db;
    //}
    //public override async Task<List<Mytbl>> GetAllAsync()
    //{
    //    return (List<Mytbl>)await _db.QueryAsync<Mytbl>("SELECT * FROM Mytbl");
    //}
}
