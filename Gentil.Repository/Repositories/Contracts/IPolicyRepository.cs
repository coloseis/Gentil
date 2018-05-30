using System;
using System.Collections.Generic;
using Gentil.Business.Models;

namespace Gentil.Repository.Repositories.Contracts
{
    public interface IPolicyRepository : IDisposable
    {
        IEnumerable<Policy> GetAll();
        Policy GetByID(Guid Id);
        void Insert(Policy entity);
        void Delete(Guid ID);
        void Update(Policy entity);
        void Save();
    }
}