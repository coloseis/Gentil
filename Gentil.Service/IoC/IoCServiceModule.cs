using Gentil.Repository.IoC;
using Gentil.Service.Services;
using Gentil.Service.Services.Contracts;
using SimpleInjector;

namespace Gentil.Service.IoC
{
    public class IoCServiceModule
    {
        public static void Inject(Container container)
        {
            IoCRepositoryModule.Inject(container);
            container.Register(typeof(IUsersService), typeof(UsersService), Lifestyle.Scoped);
        }
    }
}
