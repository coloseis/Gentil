using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Gentil.Repository.Repositories.Contracts;
using Gentil.Service.Models;
using Gentil.Service.Services.Contracts;
using Gentil.Business.Models;

namespace Gentil.Service.Services
{
    public class ClientService : IClientService
    {
        private IClientRepository _clientRepository;
        private IPolicyRepository _policyRepository;
        public ClientService(IClientRepository clientRepository, IPolicyRepository policyRepository)
        {
            this._clientRepository = clientRepository;
            this._policyRepository = policyRepository;
        }
        public ClientDTO[] GetClients()
        {
            return _clientRepository
                .GetAll()
                .Select(x => new ClientDTO { ID = x.ID, Name = x.Name, Email = x.Email, Role = x.Role })
                .ToArray();
        }
        public ClientDTO GetClientByID(Guid id)
        {
            var client = _clientRepository.GetByID(id);

            if (client == null)
            {
                return null;
            }

            return new ClientDTO { ID = client.ID, Name = client.Name, Email = client.Email, Role = client.Role };
        }
        public ClientDTO GetClientByName(string name)
        {
            var client = _clientRepository.GetAll().SingleOrDefault(x => x.Name == name);

            if (client == null)
            {
                return null;
            }

            return new ClientDTO { ID = client.ID, Name = client.Name, Email = client.Email, Role = client.Role };
        }

        public ClientDTO GetClientByEmail(string email)
        {
            var client = _clientRepository.GetAll().SingleOrDefault(x => x.Email == email);

            if (client == null)
            {
                return null;
            }

            return new ClientDTO { ID = client.ID, Name = client.Name, Email = client.Email, Role = client.Role };
        }

        public PolicyDTO[] GetPoliciesByClientName(string name)
        {
            var client = _clientRepository.GetAll().SingleOrDefault(x => x.Name == name);

            if (client == null)
            {
                return null;
            }

            var policies = _policyRepository.GetAll().Where(x => x.ClientId == client.ID);

            return policies.Select(x => new PolicyDTO()
            {
                ID = x.ID,
                AmountInsured = x.AmountInsured,
                InceptionDate = x.InceptionDate,
                InstallmentPayment = x.InstallmentPayment,
                Email = x.Email,
                ClientID = x.ClientId
            })
            .ToArray();
        }
    }
}