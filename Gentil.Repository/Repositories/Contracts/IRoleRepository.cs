using System;
using System.Collections.Generic;
using Gentil.Business.Models;

namespace Gentil.Repository.Repositories.Contracts
{
    public interface IRoleRepository : IDisposable
    {
        IEnumerable<Role> GetRoles();
        Role GetRoleByID(int roleId);
        void InsertRole(Role role);
        void DeleteRole(int roleID);
        void UpdateRole(Role role);
        void Save();
    }
}