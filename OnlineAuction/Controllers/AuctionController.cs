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
using log4net;

namespace OnlineAuction.Controllers
{
    [HandleError]
    [Authorize]
    public class AuctionController : Controller
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(string));
        private Auction.Sevices.AuctionService _auctionService = new AuctionService();

        /// <summary>
        /// Lists the active sales ( Open auctions ) - GET:
        /// </summary>
        /// <returns></returns>

        public ActionResult Index()
        {
            IEnumerable<SP_GetMaxBidUserDetails_Result> _auctionInformationList = _auctionService.GetCurrentSales();
            return View(_auctionInformationList);
        }

        public ActionResult Details(SP_GetMaxBidUserDetails_Result auctionInformation)
        {
            BidService bidService = new BidService();
            BidParticipantInformation bidParticipantInformation = null;
            try
            {
                bidParticipantInformation = bidService.GetBidParticipantInformationById((int)auctionInformation.AuctionInformationId);
            }
            catch
            {

            }
            if (bidParticipantInformation != null)
            {

                auctionInformation.MaxBidPrice = bidParticipantInformation.BidPrice;

            }
            else
            {
                auctionInformation.MaxBidPrice =(int)auctionInformation.BidBasePrice;
            }

            auctionInformation.UserId = Convert.ToInt32(Session["userId"].ToString());
            return View(auctionInformation);
        }

        // 
        /// <summary>
        /// Diplays Create Auction Page. GET: Auction/Create
        /// </summary>
        /// <returns></returns>
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
                if (ModelState.IsValid)
                {

                    collection.CreatedByUserId = Convert.ToInt32(Session["userId"].ToString());
                    _auctionService.CreateAuctionInformation(collection);
                    return RedirectToAction("Index");
                }
                else
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

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return View();
            }
        }

        // GET: Auction/Edit/5
        public ActionResult Edit(int id)
        {
            AuctionInformation _auctionInformation = null;
            IList<SelectListItem> productListType = new List<SelectListItem>
            {
                new SelectListItem{Text = "Electronics", Value = "1"},
                new SelectListItem{Text = "Clothing", Value = "2"},
                new SelectListItem{Text = "Spotrs", Value = "3"},
                new SelectListItem{Text = "Furniture", Value = "4"},
            };

            if (ModelState.IsValid)
            {
                _auctionInformation = _auctionService.GetAuctionInformationById(id);

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
            else
            {
                return View(_auctionInformation);
            }



        }


        [HttpPost]
        public ActionResult Edit(int id, AuctionInformation collection)
        {
            try
            {
                collection.CreatedByUserId = Convert.ToInt32(Session["userId"].ToString());
                _auctionService.UpdateAuctionInformation(id, collection);
                return RedirectToAction("Index");
            }
            catch ( Exception ex)
            {
                logger.Error(ex.Message);
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
            catch ( Exception ex)
            {
                logger.Error(ex.Message);
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
            catch ( Exception ex)
            {
                logger.Error(ex.Message);
                return View();
            }
            return RedirectToAction("Index", "Auction");
        }


        public ActionResult Deactivate(int id)
        {
            _auctionService.DeleteAuctionInformation(id);
            return RedirectToAction("Index", "Auction");
        }

        
        public ActionResult LatestBid(BidParticipantInformation id)
        {
             return RedirectToAction("Index", "Auction");
        }

    }
}
