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

            //Mock<MyEmail> objEmail = new Mock<MyEmail>();
            ////Specify which function you want to by pass
            //objEmail.Setup(x => x.SendEmail()).Returns(True);
            //Customer obj = new Customer();
            //bool IsInserted = obj.AddCustomer(objEmail.Object);
            User tesuser = new User();
            IUserService _objIUserService;
            _objIUserService = new UserService();
            Mock<UserService> objDB = new Mock<UserService>();
            // objDB.Setup(x => x.GetUserById("sudha")).Returns(obh);
            objDB.Setup(x => x.GetUserById(tesuser.UserName.ToString())).Returns(tesuser);
            User objuser = _objIUserService.GetUserById("smosa");

        }

        [TestMethod()]
        public void GetUserByIdTest()
        {
            Assert.Fail();
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