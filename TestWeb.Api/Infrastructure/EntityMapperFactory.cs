
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TestWeb.DAL.Entities;
using TestWeb.Infrastructure.ViewModels;

namespace TestWeb.Api.Infrastructure
{
    public class EntityMapperFactory : IEntityMapperFactory
    {
        public Product ProductFromProductView(ProductView productView)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductView, Product>();
            });

            IMapper mapper = config.CreateMapper();

            return mapper.Map<ProductView, Product>(productView);

        }

        public ProductView ProductViewFromProduct(Product product)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductView>();
            });
            IMapper mapper = config.CreateMapper();
            return mapper.Map<Product, ProductView>(product);

        }
    }
}
