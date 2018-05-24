using System;
using System.Collections.Generic;
using Gentil.Business.Models;

namespace Gentil.Repository.Repositories.Contracts
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUserByID(int userId);
        void InsertUser(User user);
        void DeleteUser(int userID);
        void UpdateUser(User user);
        void Save();
    }
}