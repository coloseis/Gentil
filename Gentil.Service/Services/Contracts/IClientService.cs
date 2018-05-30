using System;
using Gentil.Service.Models;

namespace Gentil.Service.Services.Contracts
{
    public interface IClientService
    {
        ClientDTO[] GetClients();
        ClientDTO GetClientByID(Guid id);
        ClientDTO GetClientByName(string name);
        ClientDTO GetClientByEmail(string email);
        PolicyDTO[] GetPoliciesByClientName(string name);
    }
}