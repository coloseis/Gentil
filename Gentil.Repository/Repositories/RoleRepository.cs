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
    public class RoleRepository : IRoleRepository
    {
        private DbContext _context;

        public RoleRepository(DbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Role> GetRoles()
        {
            return _context.Set<Role>().ToList();
        }

        public Role GetRoleByID(int id)
        {
            return _context.Set<Role>().Find(id);
        }

        public void InsertRole(Role role)
        {
            _context.Set<Role>().Add(role);
        }

        public void DeleteRole(int roleID)
        {
            Role role = _context.Set<Role>().Find(roleID);
            _context.Set<Role>().Remove(role);
        }

        public void UpdateRole(Role role)
        {
            _context.Entry(role).State = EntityState.Modified;
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