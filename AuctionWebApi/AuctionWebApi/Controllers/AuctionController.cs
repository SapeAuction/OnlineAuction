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
    public class AuctionController : ApiController
    {
        private IAuctionService _repository;

        public AuctionController(IAuctionService repository)
        {
            _repository = repository;
        }

        // GET: api/Auction
        public IEnumerable<AuctionInformation> Get()
        {
            return _repository.GetAllAuctionInformation();
        }

        // GET: api/Auction/5
        public AuctionInformation Get(int id)
        {
            return _repository.GetAuctionInformationById(id);
        }

        // POST: api/Auction
        public HttpResponseMessage Post([FromBody]AuctionInformation value)
        {
            
            if (_repository.CreateAuctionInformation(value))
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
            }
        }

        // PUT: api/Auction/5
        public HttpResponseMessage Put([FromBody]AuctionInformation value)
        {

            if (_repository.UpdateAuctionInformation(value))
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
            }

        }

        // DELETE: api/Auction/5
        public HttpResponseMessage Delete(int id)
        {
            if (_repository.DeleteAuctionInformation(id))
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
            }

        }
    }
}

