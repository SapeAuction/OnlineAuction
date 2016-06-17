using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Entity;
using Auction.WebApi.DataModel;
using Auction.WebApi.Sevices.Interfaces;

namespace Auction.WebApi.Sevices.Implementations
{
    public class UserService : IUserService
    {
        private AuctionDBEntities db = new AuctionDBEntities();

        public int CreateUser(User userEntity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            db.Configuration.ProxyCreationEnabled = false;

            //var BidParticipantDetails = (from u in db.BidParticipantInformations
            //                             select u).ToList<BidParticipantInformation>();
            var users = (from u in db.Users
                         select u).ToList<User>();
            return users;
        }

        public User GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(int userId, User userEntity)
        {
            throw new NotImplementedException();
        }        
    }
}
