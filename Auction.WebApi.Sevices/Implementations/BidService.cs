using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Entity;
using Auction.WebApi.Sevices.Interfaces;
using Auction.WebApi.DataModel;

namespace Auction.WebApi.Sevices.Implementations
{
    public class BidService : IBidService
    {
        private AuctionDBEntities db = new AuctionDBEntities();
        public int CreateBidParticipantInformation(BidParticipantInformation bidParticipantInformationEntity)
        {
            try
            { 
            db.Configuration.ProxyCreationEnabled = false;
            //Insert new recard
            db.BidParticipantInformations.Add(bidParticipantInformationEntity);
            int retvalue = db.SaveChanges();
            return retvalue;
            }
            catch
            {
                throw new Exception ();
            }
            

        }

        public bool DeleteBidParticipantInformation(BidParticipantInformation bidParticipantInformationEntity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BidParticipantInformation> GetAllBidParticipantInformation()
        {
            try
            { 
            db.Configuration.ProxyCreationEnabled = false;
            var BidParticipantDetails = (from u in db.BidParticipantInformations
                                         select u).ToList<BidParticipantInformation>();
            return BidParticipantDetails;
            }
            catch
            {
                throw new Exception();
            }

        }

        public BidParticipantInformation GetBidParticipantInformationById(int userId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBidParticipantInformation(BidParticipantInformation userEntity)
        {
            throw new NotImplementedException();
        }


    }
}
