using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auction.Sevices;
using Auction.Entity;

namespace OnlineAuction.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult BidInfo()
        {
            IBidService bidService = new BidService();
            IEnumerable<BidParticipantInformation> lstBids = bidService.GetAllBidParticipantInformation();

            return View(lstBids);
        }
    }
}