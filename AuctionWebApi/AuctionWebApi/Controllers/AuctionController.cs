using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Auction.WebApi.Sevices.Interfaces;
using Auction.Entity;
using log4net;

namespace AuctionWebApi.Controllers
{
    public class AuctionController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(string));
        private IAuctionService _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuctionController"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public AuctionController(IAuctionService repository)
        {
            _repository = repository;
        }

        // GET: api/Auction
        public IEnumerable<SP_GetMaxBidUserDetails_Result> Get()
        {
            logger.Debug("api/Auction");
            return _repository.GetAllAuctionInformation();
        }


        [HttpGet]
        [Route("api/Auction/GetbyID/{id}")]
        public IEnumerable<AuctionInformation> GetbyID(int id)
        {
            return _repository.GetAllAuctionInformationByID(id);
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
        public HttpResponseMessage Put(int id,[FromBody]AuctionInformation value)
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

