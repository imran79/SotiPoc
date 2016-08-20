using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeb.DAL.Entities;
using TestWeb.DAL.Repository;

namespace TestWeb.DAL.Repository
{
   public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {

        }
       
    }
}
