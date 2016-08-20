using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Data.Entity;
using System.Net.Http.Formatting;
using System.Web.Http;
using TestWeb.Api.Api;
using TestWeb.Api.Infrastructure;
using TestWeb.DAL;
using TestWeb.DAL.Entities;
using TestWeb.DAL.Repository;

namespace TestWeb.Api
{
    public static class TestWebApiConfiguration
    {

        public  static void Configuration(HttpConfiguration config)
        {
            
                config.MapHttpAttributeRoutes();

                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );

                ConfigureAutofac(config);

                config.Formatters.Clear();
                config.Formatters.Add(new JsonMediaTypeFormatter());
           

        }

        public static void ConfigureAutofac(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(typeof(ProductController).Assembly);
            builder.RegisterType<TestWebContext>().As<DbContext>().InstancePerRequest();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();         

            builder.RegisterType<EntityMapperFactory>().As<IEntityMapperFactory>().InstancePerLifetimeScope();

          
            builder.RegisterHttpRequestMessage(config);
            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
