using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeb.DAL.Entities;
using TestWeb.Infrastructure.ViewModels;

namespace TestWeb.Api.Infrastructure
{
    public interface IEntityMapperFactory
    {
        ProductView ProductViewFromProduct(Product product);
        Product ProductFromProductView(ProductView productView);
    }
}
