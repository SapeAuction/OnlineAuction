using Microsoft.VisualStudio.TestTools.UnitTesting;
using Auction.WebApi.Sevices.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Entity;
using Auction.WebApi.Sevices.Interfaces;
using Auction.WebApi;
using Moq;

namespace Auction.WebApi.Sevices.Implementations.Tests
{
    [TestClass()]
    public class AuctionServiceTests
    {
       // private AuctionWebApi.Controllers.AuctionController _objAuctionController;

        [TestMethod()]
        public void CreateAuctionInformationTest()
        {

        }

        [TestMethod()]
        public void DeleteAuctionInformationTest()
        {

        }

        [TestMethod()]
        public void GetAllAuctionInformationTest()
        {
            IAuctionService obj = new AuctionService();
            
            Mock<SP_GetMaxBidUserDetails_Result> objSP = new Mock<SP_GetMaxBidUserDetails_Result>();
            
            IEnumerable<SP_GetMaxBidUserDetails_Result> salesList = obj.GetAllAuctionInformation();
            Assert.AreEqual(objSP, salesList);
           // Assert.IsTrue(salesList.Count() > 0);
        }

        [TestMethod()]
        public void GetAllAuctionInformationByIDTest()
        {

        }

        [TestMethod()]
        public void GetAuctionInformationByIdTest()
        {

        }

        [TestMethod()]
        public void UpdateAuctionInformationTest()
        {

        }
    }
}