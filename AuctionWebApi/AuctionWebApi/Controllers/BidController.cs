using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Auction.WebApi.Sevices.Interfaces;
using Auction.Entity;

namespace AuctionWebApi.Controllers
{
    public class BidController : ApiController
    {
        private IBidService _repository;

        public BidController(IBidService repository)
        {
            _repository = repository;
        }

        // GET: api/Bid
        public IEnumerable<BidParticipantInformation> Get()
        {
            return _repository.GetAllBidParticipantInformation();
        }

        // GET: api/Bid/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Bid
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Bid/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Bid/5
        public void Delete(int id)
        {
        }
    }
}
