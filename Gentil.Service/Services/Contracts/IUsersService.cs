using Gentil.Service.Models;

namespace Gentil.Service.Services.Contracts
{
    public interface IUsersService
    {
        UserDTO[] GetUsers();
        UserDTO GetUserByID(int userId);
        void InsertUser(UserDTO dto);
        void UpdateUser(UserDTO user);
        void DeleteUser(int userID);
        UserDTO Validate(string user, string password);
    }
}