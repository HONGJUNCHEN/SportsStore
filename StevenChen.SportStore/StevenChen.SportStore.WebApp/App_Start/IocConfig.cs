using Autofac;
using Autofac.Integration.Mvc;
using Moq;
using StevenChen.SportStore.Domain.Abstract;
using StevenChen.SportStore.Domain.Concrete;
using StevenChen.SportStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StevenChen.SportStore.WebApp
{
    public class IocConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Product>
            //{
            //new Product { Name = "Football", Price = 25 },
            //new Product { Name = "Surf board", Price = 179 },
            //new Product { Name = "Running shoes", Price = 95 }
            //});
            //builder.RegisterInstance<IProductsRepository>(mock.Object);

            //builder.RegisterInstance<IProductsRepository>(new EFProductRepository());
            builder.RegisterType<EFProductRepository>().As<IProductsRepository>();
            builder.RegisterType<EmailOrderProcessor>().As<IOrderProcessor>();
            builder.RegisterType<EmailSettings>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }
}