using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Entity;

namespace Auction.UI.Sevices
{
    public interface IUserService
    {
        User GetUserById(int userId);
        IEnumerable<User> GetAllUsers();
        int CreateUser(User userEntity);
        bool UpdateUser(int userId, User userEntity);
        bool DeleteUser(int userId);
    }
}