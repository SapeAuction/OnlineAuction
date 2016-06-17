using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Auction.WebApi.Sevices.Interfaces;

namespace AuctionWebApi.Controllers
{
    public class AuctionController : ApiController
    {
        private IAuctionService _repository;

        public AuctionController(IAuctionService repository)
        {
            _repository = repository;
        }

        // GET: api/Auction
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Auction/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Auction
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Auction/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Auction/5
        public void Delete(int id)
        {
        }
    }
}
