using Microsoft.VisualStudio.TestTools.UnitTesting;
using Auction.WebApi.Sevices.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Auction.WebApi.DataModel;
using Auction.Entity;
using Auction.WebApi.Sevices.Interfaces;

using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
using System.Data.Objects;


namespace Auction.WebApi.Sevices.Implementations.Tests
{
    [TestClass()]
    public class UserServiceTests
    {
        [TestMethod()]
        public void CreateUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllUsersTest()
        {
            Assert.Fail();

        }

        [TestMethod()]
        public void GetUserByIdTest()
        {
            User tu = new User();
            Mock<AuctionDBEntities> mockAcutionDb = new Mock<AuctionDBEntities>();
            Mock<User> tesuser = new Mock<User>();
            UserService _objIUserService;
            _objIUserService = new UserService();
            Mock<UserService> objDB = new Mock<UserService>();            
            objDB.Setup(x => x.GetUserById("smosa")).Returns(tu);
            User objuser = _objIUserService.GetUserById("smosa");
            var comobj = _objIUserService.GetUserById(objDB.Object.GetUserById("smosa").UserName);
            Assert.AreEqual(objuser, comobj);
        }

        [TestMethod()]
        public void IsValidUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateUserTest()
        {
            Assert.Fail();
        }
    }
}