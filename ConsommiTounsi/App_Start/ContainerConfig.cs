using Autofac;
using Autofac.Integration.Mvc;
using ConsommiTounsi.Repositories.Payment;
using ConsommiTounsi.Repositories.Product;
using System.Web.Mvc;

namespace ConsommiTounsi
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            registerTypes(builder);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void registerTypes(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryRepository>()
                                    .As<ICategoryRepository>()
                                    .InstancePerRequest();
            builder.RegisterType<CartRepository>()
                    .As<ICartRepository>()
                    .InstancePerRequest();
            builder.RegisterType<ProductRepository>()
                    .As<IProductRepository>()
                    .InstancePerRequest();
        }
    }
}