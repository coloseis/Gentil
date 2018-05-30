using System;
using System.Collections.Generic;
using System.Linq;
using Gentil.Business.Models;
using Gentil.Repository.Repositories.Contracts;

namespace Gentil.Test.Repositories
{
    class PolicyTestRepository : IPolicyRepository
    {
        private IEnumerable<Policy> _policies;
        public PolicyTestRepository(IEnumerable<Policy> policies)
        {
            _policies = policies;
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
