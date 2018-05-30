using SimpleInjector;
using Gentil.Repository.Repositories;
using Gentil.Repository.Repositories.Contracts;
using Gentil.DAL.IoC;

namespace Gentil.Repository.IoC
{
    public class IoCRepositoryModule
    {
        public static void Inject(Container container, bool useMockyRepository)
        {
            IoCContextModule.Inject(container);

            if (useMockyRepository)
            {
                container.Register(typeof(IClientRepository), typeof(ClientMockyRepository), Lifestyle.Scoped);
                container.Register(typeof(IPolicyRepository), typeof(PolicyMockyRepository), Lifestyle.Scoped);
            }
            else
            {
                container.Register(typeof(IClientRepository), typeof(ClientRepository), Lifestyle.Scoped);
                container.Register(typeof(IPolicyRepository), typeof(PolicyRepository), Lifestyle.Scoped);
            }

        }
    }
}