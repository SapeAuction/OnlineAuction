using System.Collections.Generic;
using Auction.Entity;

namespace Auction.WebApi.Sevices.Implementations
{
    public interface IUserService
    {
        int CreateUser(User userEntity);
        bool DeleteUser(int userEntityId);
        IEnumerable<User> GetAllUsers();
        User GetUserById(string userName);
        User IsValidUser(string userName, string userPassword);
        bool UpdateUser(int uid, User userUpdatedEntity);
    }
}