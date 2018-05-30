using System;
using System.Collections.Generic;
using Gentil.Business.Models;

namespace Gentil.Repository.Repositories.Contracts
{
    public interface IClientRepository : IDisposable
    {
        IEnumerable<Client> GetAll();
        Client GetByID(Guid id);
        void Insert(Client entity);
        void Delete(Guid Guid);
        void Update(Client entity);
        void Save();
    }
}