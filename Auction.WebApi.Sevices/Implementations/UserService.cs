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
            db.Configuration.ProxyCreationEnabled = false;
            try
            {
                int createdStatus = default(int);
                if(userEntity!=null)
                { 
                db.Users.Add(userEntity);
                createdStatus = db.SaveChanges();                
                }
                return createdStatus;
            }
            catch
            {
                throw new Exception();
            }
        }

        public bool DeleteUser(int userEntityId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            try
            {
                bool deletStatus = default(bool);
                //Ned to featch all USer 
                var user = (from u in db.Users
                            where u.UserId == userEntityId select u).FirstOrDefault<User>();
                if(user!=null)
                { 
                    db.Users.Remove(user);
                    int createdStatus = db.SaveChanges();
                    deletStatus = true;
                }

                return deletStatus;
            }
            catch
            {
                throw new Exception();
            }
           
        }

        public IEnumerable<User> GetAllUsers()
        {
            db.Configuration.ProxyCreationEnabled = false;
            try
            {
                 var users = (from u in db.Users
                             select u).ToList<User>();
                return users;
            }
            catch
            {
                throw new Exception();
            }
        }
        
        public User GetUserById(string userName)
        {
            db.Configuration.ProxyCreationEnabled = false;
            try
            {
                 var users = (from u in db.Users
                             where u.UserName== userName
                             select u).FirstOrDefault<User>();
                return users;
            }
            catch
            {
                throw new Exception();
            }
        }

        public User IsValidUser(string userName, string userPassword)
        {
            db.Configuration.ProxyCreationEnabled = false;
            try
            {
                var validUser = (from u in db.Users
                                 where (u.UserName == userName && u.Password == userPassword)
                                 select u).FirstOrDefault<User>();
                return validUser;
            }
            catch
            {
                throw new Exception();
            }
        }

        public bool UpdateUser( int uid,User userUpdatedEntity)
        {
            db.Configuration.ProxyCreationEnabled = false;
            try
            {
                bool updatedStastus = default(bool);
                int userIdToModify = default(int);
                if (userUpdatedEntity != null)
                {
                    if (uid >0 )
                        userIdToModify = (from u in db.Users
                                          select userUpdatedEntity).FirstOrDefault<User>().UserId;
                    else
                        userIdToModify = uid;

                    //Finding out User object from DB
                    User objUser = (from u in db.Users
                                    where u.UserId == userIdToModify
                                    select u).FirstOrDefault<User>();
                    objUser.UserName = userUpdatedEntity.UserName;
                    objUser.Address = userUpdatedEntity.Address;
                    objUser.Status = userUpdatedEntity.Status;
                    objUser.Password = userUpdatedEntity.Password;
                    db.SaveChanges();
                    //db.Database.ExecuteSqlCommand()
                    updatedStastus = true;
                }
                return updatedStastus;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }        
    }
}
