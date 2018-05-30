using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Gentil.Business.Models;
using Gentil.Repository.Repositories.Contracts;
using Gentil.DAL.Contexts;
using RestSharp;

namespace Gentil.Repository.Repositories
{
    public class ClientsMock
    {
        public List<Client> Clients { get; set; }
    }

    public class ClientMockyRepository : IClientRepository
    {
        private IEnumerable<Client> _clients;
        public ClientMockyRepository()
        {
            IRestClient restClient = new RestClient("http://www.mocky.io/v2/5808862710000087232b75ac");
            IRestRequest request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            _clients = restClient.Execute<ClientsMock>(request).Data.Clients;
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