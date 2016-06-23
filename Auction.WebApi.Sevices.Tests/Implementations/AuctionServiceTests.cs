using Microsoft.VisualStudio.TestTools.UnitTesting;
using Auction.WebApi.Sevices.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Entity;

namespace Auction.WebApi.Sevices.Implementations.Tests
{
    [TestClass()]
    public class AuctionServiceTests
    {
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
            AuctionService obj = new AuctionService();
            IEnumerable<SP_GetMaxBidUserDetails_Result> salesList = obj.GetAllAuctionInformation();

            Assert.IsTrue(salesList.Count() > 0);
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