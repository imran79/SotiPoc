
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TestWeb.DAL.Entities;
using TestWeb.Infrastructure.ViewModels;
using System.Web.Http.Routing;


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

        public ProductView ProductViewFromProduct(Product product,UrlHelper url)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductView>();
            });
            IMapper mapper = config.CreateMapper();
            var productView = mapper.Map<Product, ProductView>(product);
             productView.Links = CreateLink(product, url);
            return productView;

        }

        private List<Link> CreateLink(Product product,UrlHelper url)
        {
            return new List<Link>
            {
                new Link
                {
                    Method = "Get",
                    Rel="Self",
                    Href=url.Link("DefaultApi",new {controller="ProductController",id=product.Id})
                }
            };               

        }
    }
}
