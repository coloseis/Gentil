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
    public class ClientRepository : IClientRepository
    {
        private DbContext _context;

        public ClientRepository(DbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Client> GetAll()
        {
            return _context.Set<Client>().ToList();
        }

        public Client GetByID(Guid id)
        {
            return _context.Set<Client>().Find(id);
        }

        public void Insert(Client entity)
        {
            _context.Set<Client>().Add(entity);
        }

        public void Delete(Guid id)
        {
            Client entity = _context.Set<Client>().Find(id);
            _context.Set<Client>().Remove(entity);
        }

        public void Update(Client entity)
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