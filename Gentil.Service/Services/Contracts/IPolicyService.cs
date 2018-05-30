using System;
using Gentil.Service.Models;

namespace Gentil.Service.Services.Contracts
{
    public interface IPolicyService
    {
        PolicyDTO GetPolicyByID(Guid id);
        ClientDTO GetClientByPolicyId(Guid id);
        PolicyDTO[] GetPoliciesByClientId(Guid id);
    }
}