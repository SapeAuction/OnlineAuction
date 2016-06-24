using Auction.Entity;
using Auction.UI.Sevices;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OnlineAuction.Controllers
{
    public class ProductsController : Controller
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(string));

        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            ProductService test = new ProductService();
            Product obj= test.GetProductById(1);

            return View(obj);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
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
    }
}
