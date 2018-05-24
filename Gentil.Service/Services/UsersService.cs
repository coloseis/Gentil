using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Gentil.Repository.Repositories.Contracts;
using Gentil.Service.Models;
using Gentil.Service.Services.Contracts;

namespace Gentil.Service.Services
{
    public class UsersService : IUsersService
    {
        private IUserRepository _userRepository;
        public UsersService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public UserDTO[] GetUsers()
        {
            return _userRepository
                .GetUsers()
                .ToList()
                .Select(x => new UserDTO { ID = x.ID, Name = x.Name, Role = x.Role.Name })
                .ToArray();
        }

        public UserDTO Validate(string name, string password)
        {
            var user = _userRepository
                .GetUsers()
                .SingleOrDefault(x => x.Name == name && x.Password == password);

            if (user != null)
            {
                return new UserDTO { ID = user.ID, Name = user.Name, RoleID = user.Role.ID, Role = user.Role.Name };
            }

            return null;
        }
    }
}