using Gentil.Repository.IoC;
using Gentil.Service.Services;
using Gentil.Service.Services.Contracts;
using SimpleInjector;

namespace Gentil.Service.IoC
{
    public class IoCServiceModule
    {
        public static void Inject(Container container, bool useMockyRepository)
        {
            IoCRepositoryModule.Inject(container, useMockyRepository);
            container.Register(typeof(IClientService), typeof(ClientService), Lifestyle.Scoped);
            container.Register(typeof(IPolicyService), typeof(PolicyService), Lifestyle.Scoped);
        }
    }
}
