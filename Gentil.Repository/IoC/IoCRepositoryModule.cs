using SimpleInjector;
using Gentil.Repository.Repositories;
using Gentil.Repository.Repositories.Contracts;
using Gentil.DAL.IoC;

namespace Gentil.Repository.IoC
{
    public class IoCRepositoryModule
    {
        public static void Inject(Container container)
        {
            IoCContextModule.Inject(container);
            container.Register(typeof(IUserRepository), typeof(UserRepository), Lifestyle.Scoped);
        }
    }
}
