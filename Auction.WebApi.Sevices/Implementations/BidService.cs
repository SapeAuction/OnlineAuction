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
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public bool DeleteBidParticipantInformation(BidParticipantInformation bidParticipantInformationEntity)
        {
            bool isSuccess = true;

            BidParticipantInformation bidInfo = db.BidParticipantInformations.SingleOrDefault(p => p.BidParticipantInformationId == bidParticipantInformationEntity.BidParticipantInformationId);
            db.BidParticipantInformations.Remove(bidInfo);
            db.SaveChanges();

            return isSuccess;
        }

        public IEnumerable<BidParticipantInformation> GetAllBidParticipantInformation()
        {
            try
            {
                //db.Configuration.ProxyCreationEnabled = false;
                //var BidParticipantDetails = (from u in db.BidParticipantInformations
                //                             select u).ToList<BidParticipantInformation>();
                //return BidParticipantDetails;

                db.Configuration.ProxyCreationEnabled = false;

                IEnumerable<BidParticipantInformation> BidParticipantDetails = (from b in db.BidParticipantInformations
                                                                                join a in db.AuctionInformations on b.AuctionInformationId equals a.AuctionInformationId
                                                                                join u in db.Users on b.UserId equals u.UserId
                                                                                select new { b, a, u }).ToList()
                                                                               .Select(x => new BidParticipantInformation
                                                                               {
                                                                                   BidParticipantInformationId = x.b.BidParticipantInformationId,
                                                                                   UserId = x.b.UserId,
                                                                                   AuctionInformationId = x.b.AuctionInformationId,
                                                                                   BidPrice = x.b.BidPrice,
                                                                                   BidCreationDateTime = x.b.BidCreationDateTime,
                                                                                   User = new User { UserName = x.u.UserName },
                                                                                   AuctionInformation = new AuctionInformation { BidBasePrice = x.a.BidBasePrice }
                                                                               });

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

        public bool UpdateBidParticipantInformation(BidParticipantInformation bidParticipantInformation)
        {
            bool isSuccess = true;

            BidParticipantInformation bidInfo = db.BidParticipantInformations.SingleOrDefault(p => p.BidParticipantInformationId == bidParticipantInformation.BidParticipantInformationId);

            bidInfo.BidPrice = bidParticipantInformation.BidPrice;

            db.Entry(bidInfo).State = System.Data.EntityState.Modified;
            db.SaveChanges();

            return isSuccess;
        }


    }
}
