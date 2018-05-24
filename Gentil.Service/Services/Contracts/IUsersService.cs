using Gentil.Service.Models;

namespace Gentil.Service.Services.Contracts
{
    public interface IUsersService
    {
        UserDTO[] GetUsers();

        UserDTO Validate(string user, string password);
    }
}