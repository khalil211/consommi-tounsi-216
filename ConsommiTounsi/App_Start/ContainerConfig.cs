using Autofac;
using Autofac.Integration.Mvc;
using ConsommiTounsi.Data.Repositories.Payment;
using System.Web.Mvc;

namespace ConsommiTounsi
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<InMemoryCartRepository>()
                        .As<ICartRepository>()
                        .InstancePerLifetimeScope();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}