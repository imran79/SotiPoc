using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using TestWeb.DAL.Entities;
using System.Threading.Tasks;

namespace TestWeb.DAL.Repository
{
    public interface IRepository<T> where T : IEntity
    {
        Task  Add(T Entity);
        Task Update(T Entity);
        Task Delete(T Entity);
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
    }
}