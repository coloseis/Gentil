using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Gentil.Repository.Repositories.Contracts;
using Gentil.Service.Models;
using Gentil.Service.Services.Contracts;
using Gentil.Business.Models;

namespace Gentil.Service.Services
{
    public class UsersService : IUsersService
    {
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        public UsersService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this._userRepository = userRepository;
            this._roleRepository = roleRepository;
        }

        public UserDTO[] GetUsers()
        {
            return _userRepository
                .GetUsers()
                .ToList()
                .Select(x => new UserDTO { ID = x.ID, Name = x.Name, Role = x.Role.Name })
                .ToArray();
        }

        public UserDTO GetUserByID(int userId)
        {
            var user = _userRepository.GetUserByID(userId);

            if (user == null)
            {
                return null;
            }

            return new UserDTO { ID = user.ID, Name = user.Name, Password = user.Password, RoleID = user.Role.ID.ToString(), Role = user.Role.Name };
        }

        public void InsertUser(UserDTO dto)
        {
            var user = new User();
            user.Name = dto.Name;
            user.Password = dto.Password;
            user.Role = _roleRepository.GetRoleByID(int.Parse(dto.RoleID));

            _userRepository.InsertUser(user);
            _userRepository.Save();
        }

        public void UpdateUser(UserDTO dto)
        {
            var user = _userRepository.GetUserByID(dto.ID);

            user.Name = dto.Name;
            user.Password = dto.Password;
            user.Role = _roleRepository.GetRoleByID(int.Parse(dto.RoleID));

            _userRepository.UpdateUser(user);
            _userRepository.Save();
        }

        public void DeleteUser(int userID)
        {
            _userRepository.DeleteUser(userID);
            _userRepository.Save();
        }

        public UserDTO Validate(string name, string password)
        {
            var user = _userRepository
                .GetUsers()
                .SingleOrDefault(x => x.Name == name && x.Password == password);

            if (user != null)
            {
                return new UserDTO { ID = user.ID, Name = user.Name, RoleID = user.Role.ID.ToString(), Role = user.Role.Name };
            }

            return null;
        }
    }
}