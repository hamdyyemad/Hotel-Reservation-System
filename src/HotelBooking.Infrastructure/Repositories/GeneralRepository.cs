﻿using HotelBooking.Infrastructure.Data;
using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace HotelBooking.Infrastructure.Repositories
{
    public class GeneralRepository<T>  where T :  BaseModel
    {
        Context _context;
        DbSet<T> _dbSet; 
        public GeneralRepository()
        {
            _context = new Context();
            _dbSet = _context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            var res =  _dbSet.Where(x => !x.IsDeleted);
            return res;
        }
        public async Task<T> GetByID(int id)
        {
            var res = await _dbSet.Where(c => c.ID == id && !c.IsDeleted).FirstOrDefaultAsync();
            return res;
        }
        public async Task<bool> ExistById(int id)
        {
            return await _dbSet.AnyAsync(c => c.ID == id && !c.IsDeleted);
        }
        public IQueryable<T> Get(Expression<Func<T,bool>> expression)
        {
            var res =  GetAll().Where(expression);
            return res;
        }
        public async Task<T> GetByIDWithTracking(int id)
        {
            var res = await _dbSet.AsTracking().Where(c => c.ID == id).FirstOrDefaultAsync();
            return res;
        }
        public async Task Add(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Update(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var res = await GetByIDWithTracking(id);
            res.IsDeleted = true;   

            await _context.SaveChangesAsync();
        }
        public void UpdateInclude(T entity , params string[] modifiedParams)
        {
            if(!_dbSet.Any(x => x.ID == entity.ID))
                { return; }

            var local = _dbSet.Local.FirstOrDefault(x => x.ID == entity.ID);
            EntityEntry entityEntry;

            if(local == null)
            {
                entityEntry = _context.Entry(entity);
            }
            else
            {
                entityEntry = _context.ChangeTracker.Entries<T>().FirstOrDefault(x => x.Entity.ID == entity.ID);
            }

            foreach( var prop in entityEntry.Properties)
            {
                if(modifiedParams.Contains(prop.Metadata.Name))
                {
                    prop.CurrentValue = entity.GetType().GetProperty(prop.Metadata.Name).GetValue(entity);
                    prop.IsModified = true; 
                }
            }
            _context.SaveChanges();
        }

    }
}

