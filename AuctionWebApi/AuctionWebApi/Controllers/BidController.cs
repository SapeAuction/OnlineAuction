using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Auction.WebApi.Sevices.Interfaces;
using Auction.Entity;
using System.Web.Http.Description;

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
        public BidParticipantInformation Get(int id)
        {
            return _repository.GetBidParticipantInformationById(id);
        }

        // POST: api/Bid
        [ResponseType(typeof(BidParticipantInformation))]
        public IHttpActionResult Post(BidParticipantInformation bidParticipantInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.CreateBidParticipantInformation(bidParticipantInformation);

            return CreatedAtRoute("DefaultApi", new { id = bidParticipantInformation.BidParticipantInformationId }, bidParticipantInformation);
        }

        // PUT: api/Bid/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Bid/5
        [ResponseType(typeof(BidParticipantInformation))]
        public IHttpActionResult Delete(int id)
        {
            _repository.DeleteBidParticipantInformation(new BidParticipantInformation { BidParticipantInformationId = id });

            return Ok();
        }
    }
}
