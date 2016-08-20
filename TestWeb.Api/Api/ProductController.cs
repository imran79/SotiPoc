using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TestWeb.Api.Infrastructure;
using TestWeb.DAL.Entities;
using TestWeb.DAL.Repository;
using TestWeb.Infrastructure.ViewModels;

namespace TestWeb.Api.Api
{
    [CustomExceptionFilter]
    public class ProductController : ApiController
    {
        private IRepository<Product> _productRepository;
        private IEntityMapperFactory _entityMapperFactory;
      
        public ProductController(IRepository<Product> repository, IEntityMapperFactory entityMapperFactory)
        {
            _productRepository = repository;
            _entityMapperFactory = entityMapperFactory;
        }

        public async Task<HttpResponseMessage> Get()
        {
            var products = await _productRepository.GetAll();
            var productViews = new List<ProductView>();
            foreach (var product in products)
            {
                productViews.Add(_entityMapperFactory.ProductViewFromProduct(product));
            }
            return Request.CreateResponse(HttpStatusCode.OK, productViews);
        }

        public async Task<HttpResponseMessage> Get(int id)
        {
            var product = await _productRepository.GetById(id);
            if (product == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, _entityMapperFactory.ProductViewFromProduct(product));
        }

        public async Task<HttpResponseMessage> Post(ProductView productView)
        {
            var product = _entityMapperFactory.ProductFromProductView(productView);
            await _productRepository.Add(product);
            var response = Request.CreateResponse(HttpStatusCode.Created);            
            return response;
        }

        public async Task<HttpResponseMessage> Put(int id, ProductView productView)
        {
            var prodInStore = await _productRepository.GetById(id);
            if (prodInStore == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            var product = _entityMapperFactory.ProductFromProductView(productView);
          await  _productRepository.Update(product);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            var product = await _productRepository.GetById(id);
            if (product == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
           await _productRepository.Delete(product);
            return Request.CreateResponse(HttpStatusCode.OK);

        }
    }
}


