using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Auction.WebApi.Sevices.Interfaces;
using Auction.Entity;

namespace AuctionWebApi.Controllers
{
    public class ProductController : ApiController
    {
        private IProductService _repository;

        public ProductController(IProductService repository)
        {
            _repository = repository;
        }

        // GET: api/Product
        public IEnumerable<Product> Get()
        {
            return _repository.GetAllProducts();
        }

        // GET: api/Product/5
        public Product Get(int id)
        {
            return _repository.GetProductById(id);
        }

        // POST: api/Product
        public HttpResponseMessage Post([FromBody]Product inputEntity)
        {
            if (inputEntity == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
               int status = _repository.CreateProduct(inputEntity);
                if (status > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Product created YAYYAY");
                }
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
