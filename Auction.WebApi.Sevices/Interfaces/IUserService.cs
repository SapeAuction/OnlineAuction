﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Entity;

namespace Auction.WebApi.Sevices.Interfaces
{
    public interface IUserService
    {
        User GetUserById(string  userName);
        IEnumerable<User> GetAllUsers();
        int CreateUser(User userEntity);
        bool UpdateUser(int userId, User userEntity);
        bool DeleteUser(int userId);
    }
}