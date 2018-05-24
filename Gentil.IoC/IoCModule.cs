using System.Reflection;
using Gentil.Service.Services;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Gentil.Service.Services.Contracts;

namespace Gentil.IoC
{
    public class IoCModule
    {
        public static Container SimpleInjectorWebApiContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            SetContainer(container, Assembly.GetCallingAssembly());

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            return container;
        }

        public static void SetContainer(Container container, Assembly assembly)
        {
            container.Register<IUsersService, UsersService>(Lifestyle.Scoped);
        }
    }
}