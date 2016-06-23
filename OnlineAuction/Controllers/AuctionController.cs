using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auction.Sevices;
using Auction.Entity;
using Auction.UI.Sevices;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace OnlineAuction.Controllers
{
    public class AuctionController : Controller
    {

        private Auction.Sevices.AuctionService _auctionService = new AuctionService();

        // GET: Auction
        public ActionResult Index()
        {
            IEnumerable<SP_GetMaxBidUserDetails_Result> _auctionInformationList = _auctionService.GetCurrentSales();
            return View(_auctionInformationList);
        }

        // GET: Auction/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Auction/Create
        public ActionResult Create()
        {
            IList<SelectListItem> productListType = new List<SelectListItem>
            {
                new SelectListItem{Text = "Electronics", Value = "1"},
                new SelectListItem{Text = "Clothing", Value = "2"},
                new SelectListItem{Text = "Spotrs", Value = "3"},
                new SelectListItem{Text = "Furniture", Value = "4"},
              
            };

            ViewBag.typeList = productListType;

            return View();
        }

        // POST: Auction/Create
        [HttpPost]
        public ActionResult Create(AuctionInformation collection)
        {
            try
            {
                collection.CreatedByUserId = 1;
                _auctionService.CreateAuctionInformation(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Auction/Edit/5
        public ActionResult Edit(int id)
        {

            IList<SelectListItem> productListType = new List<SelectListItem>
            {
                new SelectListItem{Text = "Electronics", Value = "1"},
                new SelectListItem{Text = "Clothing", Value = "2"},
                new SelectListItem{Text = "Spotrs", Value = "3"},
                new SelectListItem{Text = "Furniture", Value = "4"},
            };

           
            AuctionInformation _auctionInformation = _auctionService.GetAuctionInformationById(id);

            foreach (SelectListItem test in productListType)
            {
                if (test.Value.Equals(_auctionInformation.Product.ProductTypeId.ToString()))
                {
                    test.Selected = true;
                }
            }

            ViewBag.typeList = productListType;
            return View(_auctionInformation);

        }

        // POST: Auction/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AuctionInformation collection)
        {
            try
            {
                collection.CreatedByUserId = 1;
                _auctionService.UpdateAuctionInformation(id,collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Auction/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Auction/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult PlaceBid(FormCollection bidCollection, String AuctionInformationId, String UserId)
        {
            BidParticipantInformation placeBidInfo = new BidParticipantInformation
            {
                UserId = Convert.ToInt32(UserId),
                AuctionInformationId = Convert.ToInt32(AuctionInformationId),
                BidPrice = Convert.ToDecimal(bidCollection["newBidPrice"]),
                BidCreationDateTime = DateTime.Now,
                AuctionInformation = null
            };

            try
            {
                _auctionService.saveLatestBidInformation(placeBidInfo);
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index", "Auction");
        }

       
        public ActionResult Deactivate(int id)
        {
             _auctionService.DeleteAuctionInformation(id);
            return RedirectToAction("Index", "Auction");
        }

    }
}
