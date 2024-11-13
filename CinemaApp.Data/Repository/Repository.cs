using CinemaApp.Data.Repository.Intefaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Repository
{
    public class Repository<TType, TId> : IRepository<TType, TId>
        where TType : class
    {
        private readonly CinemaDbContext dbContext;
        private readonly DbSet<TType> dbSet;

        public Repository(CinemaDbContext dbContext)
        {
                this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TType>();
        }
        public void Add(TType item)
        {
            this.dbSet.Add(item);
            this.dbContext.SaveChanges();
        }

        public async Task AddAsync(TType item)
        {
           await this.dbSet.AddAsync(item);
            await this.dbContext.SaveChangesAsync();
        }

        public bool Delete(TId id)
        {
            TType type = this.GetById(id);
            if (type == null)
            {
                return false;
            }
            this.dbSet.Remove(type);
            this.dbContext.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteAsync(TId id)
        {
            TType type = await this.GetByIdAsync(id);
            if (type == null)
            {
                return false;
            }
            this.dbSet.Remove(type);
         await   this.dbContext.SaveChangesAsync();

            return true;
        }

        public IEnumerable<TType> GetAll()
        {
           return this.dbSet.ToArray();
        }
        public IEnumerable<TType> GetAllAttached()
        {
            return this.dbSet.AsQueryable();
        }

        public async Task<IEnumerable<TType>> GetAllAsync()
        {
            return await this.dbSet.ToArrayAsync();
        }

        public TType GetById(TId id)
        {
            TType entity = this.dbSet.Find(id);
            return entity;
        }

        public async Task<TType> GetByIdAsync(TId id)
        {
            TType entity = await this.dbSet.FindAsync(id);
            return entity;
        }

       

       

        public bool Update(TType item)
        {
            try
            {
                this.dbSet.Attach(item);
                this.dbContext.Entry(item).State = EntityState.Modified;
                this.dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

              return false;
            }
            
        
        }

        public async Task<bool> UpdateAsync(TType item)
        {
            try
            {
                this.dbSet.Attach(item);
                this.dbContext.Entry(item).State = EntityState.Modified;
               await this.dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
    }
}
