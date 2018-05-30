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
    public class PoliciesMock
    {
        public List<Policy> Policies { get; set; }
    }
    public class PolicyMockyRepository : IPolicyRepository
    {
        private IEnumerable<Policy> _policies;
        public PolicyMockyRepository()
        {
            IRestClient restClient = new RestClient("http://www.mocky.io/v2/580891a4100000e8242b75c5");
            IRestRequest request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            _policies = restClient.Execute<PoliciesMock>(request).Data.Policies;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }

        public IEnumerable<Policy> GetAll()
        {
            return _policies;
        }

        public Policy GetByID(Guid id)
        {
            return _policies.SingleOrDefault(x => x.ID == id);
        }

        public void Insert(Policy entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {

        }

        public void Update(Policy entity)
        {
            throw new NotImplementedException();
        }
    }
}