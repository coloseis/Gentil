using System;
using System.Collections.Generic;
using System.Linq;
using Gentil.Business.Models;
using Gentil.Repository.Repositories.Contracts;

namespace Gentil.Test.Repositories
{
    class ClientTestRepository : IClientRepository
    {
        private IEnumerable<Client> _clients;
        public ClientTestRepository(IEnumerable<Client> clients)
        {
            _clients = clients;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }

        public IEnumerable<Client> GetAll()
        {
            return _clients;
        }

        public Client GetByID(Guid id)
        {
            return _clients.SingleOrDefault(x => x.ID == id);
        }

        public void Insert(Client entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {

        }

        public void Update(Client entity)
        {
            throw new NotImplementedException();
        }
    }
}
