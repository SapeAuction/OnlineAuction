using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auction.UI.Sevices;
using Auction.Entity;
using System.Web.UI.WebControls;

namespace OnlineAuction.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (TempData["LoginDetails"] != null)
            {
                String userName = TempData["LoginDetails"].ToString();
                TempData["LoginDetails"] = userName;
            }
//    this.HttpContext.Response.Cookies.Add
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Online Auction Support Team.";

            return View();
        }

        public ActionResult BidInfo()
        {
            IBidService bidService = new BidService();
            IEnumerable<BidParticipantInformation> lstBids = bidService.GetAllBidParticipantInformation();
            return View(lstBids);
        }
        public ActionResult GetAllUsers()
        {
            return View();
        }
    }
}