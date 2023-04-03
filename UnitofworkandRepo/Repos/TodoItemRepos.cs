﻿using Microsoft.EntityFrameworkCore;
using UnitofworkandRepo.Interface;
using UnitofworkandRepo.Models;

namespace UnitofworkandRepo.Repos
{
    public class TodoItemRepos : GenericRepository<TodoItem>, iToDoItemRepository
    {
        public TodoItemRepos(TestContext test) : base(test)
        {
        }
        public override Task<List<TodoItem>> GetAllAsync()
        {
            return base.GetAllAsync();
            //dapper
            //return (List<TodoItem>)await _db.QueryAsync<Mytbl>("SELECT * FROM TodoItem");
        }
        public override async Task<TodoItem> GetAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(item => item.Id == id);
        }
        public override async Task<bool> AddEntity(TodoItem entity)
        {
            try
            {
                await DbSet.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override async Task<bool> UpdateEntity(TodoItem entity)
        {
            try
            {
                var existdata = await DbSet.FirstOrDefaultAsync(item => item.Id == entity.Id);
                if (existdata != null)
                {
                    existdata.Id = entity.Id;
                    existdata.Name = entity.Name;
                    existdata.Description = entity.Description;
                    existdata.Description2 = entity.Description2;
                    existdata.Description3 = entity.Description3;
                    existdata.IsComplete = entity.IsComplete;
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
}
