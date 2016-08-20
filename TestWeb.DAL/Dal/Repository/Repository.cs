using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TestWeb.DAL.Entities;

namespace TestWeb.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {

        internal DbContext _testWebContext;

        public Repository(DbContext testWebContext)
        {
            _testWebContext = testWebContext;
        }

        public IDbSet<T> EntityContext
        {
            get
            {
                return _testWebContext.Set<T>();
            }

        }
        public async Task Add(T entity)
        {
           // EntityContext.Attach(entity);
            EntityContext.Add(entity);          
           await _testWebContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await EntityContext.AsNoTracking().ToListAsync();
        }

        public async Task Update(T entity)
        {
           
            _testWebContext.Entry<T>(entity).State = EntityState.Modified;
            await _testWebContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _testWebContext.Entry<T>(entity).State = EntityState.Deleted;
            await _testWebContext.SaveChangesAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await EntityContext.AsNoTracking().FirstOrDefaultAsync<T>(c => c.Id == id);
        }   
        
     
    }
}