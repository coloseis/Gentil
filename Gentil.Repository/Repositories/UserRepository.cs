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
    public class UserRepository : IUserRepository
    {
        private DbContext _context;

        public UserRepository(DbContext context)
        {
            this._context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Set<User>().ToList();
        }

        public User GetUserByID(int id)
        {
            return _context.Set<User>().Find(id);
        }

        public void InsertUser(User user)
        {
            _context.Set<User>().Add(user);
        }

        public void DeleteUser(int userID)
        {
            User user = _context.Set<User>().Find(userID);
            _context.Set<User>().Remove(user);
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
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