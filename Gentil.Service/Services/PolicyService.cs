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
    public class PolicyService : IPolicyService
    {
        private IPolicyRepository _policyRepository;
        private IClientRepository _clientRepository;
        public PolicyService(IPolicyRepository policyRepository, IClientRepository clientRepository)
        {
            this._policyRepository = policyRepository;
            this._clientRepository = clientRepository;
        }

        public PolicyDTO GetPolicyByID(Guid id)
        {
            var policy = _policyRepository.GetByID(id);

            if (policy == null)
            {
                return null;
            }

            return new PolicyDTO
            {
                ID = policy.ID,
                AmountInsured = policy.AmountInsured,
                InceptionDate = policy.InceptionDate,
                InstallmentPayment = policy.InstallmentPayment,
                Email = policy.Email,
                ClientID = policy.ClientId
            };
        }

        public ClientDTO GetClientByPolicyId(Guid id)
        {
            var policy = _policyRepository.GetByID(id);

            if (policy == null)
            {
                return null;
            }

            var client = _clientRepository.GetByID(policy.ClientId);

            return new ClientDTO { ID = client.ID, Name = client.Name, Email = client.Email, Role = client.Role };
        }

        public PolicyDTO[] GetPoliciesByClientId(Guid id)
        {
            var policies = _policyRepository.GetAll().Where(x => x.ClientId == id);

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