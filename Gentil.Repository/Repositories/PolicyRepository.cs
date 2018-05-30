using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Gentil.Business.Models;
using Gentil.Repository.Repositories.Contracts;
using Gentil.DAL.Contexts;

namespace Gentil.Repository.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        private DbContext _context;

        public PolicyRepository(DbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Policy> GetAll()
        {
            return _context.Set<Policy>().ToList();
        }

        public Policy GetByID(Guid id)
        {
            return _context.Set<Policy>().Find(id);
        }

        public void Insert(Policy entity)
        {
            _context.Set<Policy>().Add(entity);
        }

        public void Delete(Guid id)
        {
            Policy entity = _context.Set<Policy>().Find(id);
            _context.Set<Policy>().Remove(entity);
        }

        public void Update(Policy entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}