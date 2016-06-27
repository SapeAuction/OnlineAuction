using OnlineAuction.Controllers;
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Auction.Entity;
using Auction.UI.Sevices;
using Moq;
using System.Collections.Generic;

namespace OnlineAuction.Controllers.Tests
{
    [TestClass()]
    public class AccountControllerTest
    {
        [TestMethod()]
        public void LoginTest()
        {
            AccountController objLogin = new AccountController();
            //objLogin.Login (new )
        }
        //[TestMethod()]
        //public void GetAllUsersTest()
        //{

        //    //Mock<MyEmail> objEmail = new Mock<MyEmail>();
        //    ////Specify which function you want to by pass
        //    //objEmail.Setup(x => x.SendEmail()).Returns(True);
        //    //Customer obj = new Customer();
        //    //bool IsInserted = obj.AddCustomer(objEmail.Object);
        //    User tesuser = new User();
        //    IUserService _objIUserService;
        //    _objIUserService = new UserService();
        //    Mock<UserService> objDB = new Mock<UserService>();
        //    // objDB.Setup(x => x.GetUserById("sudha")).Returns(obh);
        //    objDB.Setup(x => x.GetUserById(tesuser.UserName.ToString())).Returns(tesuser);
        //    User objuser = _objIUserService.GetUserById("smosa");

        //}

        [TestMethod()]
        public void Get_All_Returns_AllCategory()
        {
            // Arrange   
            IEnumerable<User> fakeCategories = GetCategories();

            User tesuser = new User();
            IUserService _objIUserService;
            _objIUserService = new UserService();
            Mock<UserService> objDB = new Mock<UserService>();
            objDB.Setup(x => x.GetAllUsers()).Returns(fakeCategories);

            // Act
            var categories = _objIUserService.GetAllUsers();
            // Assert
            Assert.IsNotNull(categories, "Result is null");
        }
        //Assert.IsInstanceOf(typeof(IEnumerable<User>), categories, "Wrong Model");
        //Assert.AreEqual(3, categories.Count(), "Got wrong number of Categories");        }

        private static IEnumerable<User> GetCategories()
        {
            IEnumerable<User> fakeCategories = new List<User> {
    new User {UserId=1, UserName="sanjay",Address="ITPL", Status=true, CreatedDate=System.DateTime.Now, Password="xxx"}

    };
            return fakeCategories;
        }

    }
}
