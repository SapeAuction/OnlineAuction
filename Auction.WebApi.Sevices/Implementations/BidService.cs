using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Entity;
using Auction.WebApi.Sevices.Interfaces;
using Auction.WebApi.DataModel;
using log4net;

namespace Auction.WebApi.Sevices.Implementations
{
    public class BidService : IBidService
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(string));
        private AuctionDBEntities db = new AuctionDBEntities();

        /// <summary>
        /// Creates the bid participant information.
        /// </summary>
        /// <param name="bidParticipantInformationEntity">The bid participant information entity.</param>
        /// <returns></returns>
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
                logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Deletes the bid participant information.
        /// </summary>
        /// <param name="bidParticipantInformationEntity">The bid participant information entity.</param>
        /// <returns></returns>
        public bool DeleteBidParticipantInformation(BidParticipantInformation bidParticipantInformationEntity)
        {
            bool isSuccess = true;

            BidParticipantInformation bidInfo = db.BidParticipantInformations.SingleOrDefault(p => p.BidParticipantInformationId == bidParticipantInformationEntity.BidParticipantInformationId);
            db.BidParticipantInformations.Remove(bidInfo);
            db.SaveChanges();

            return isSuccess;
        }

        /// <summary>
        /// Gets all bid participant information.
        /// </summary>
        /// <returns></returns>
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
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }

        }

        public BidParticipantInformation GetBidParticipantInformationById(int acutionId)
        {

            db.Configuration.ProxyCreationEnabled = false;

            BidParticipantInformation bidInfo = (from bidinfo in db.BidParticipantInformations
                                                where bidinfo.AuctionInformationId == acutionId
                                                orderby bidinfo.BidPrice descending
                                                select bidinfo).FirstOrDefault();


            return bidInfo;
        }

        /// <summary>
        /// Updates the bid participant information.
        /// </summary>
        /// <param name="bidParticipantInformation">The bid participant information.</param>
        /// <returns></returns>
        public bool UpdateBidParticipantInformation(BidParticipantInformation bidParticipantInformation)
        {
            bool isSuccess = true;

            BidParticipantInformation bidInfo = db.BidParticipantInformations.SingleOrDefault(p => p.BidParticipantInformationId == bidParticipantInformation.BidParticipantInformationId);

            bidInfo.BidPrice = bidParticipantInformation.BidPrice;

            db.Entry(bidInfo).State = System.Data.EntityState.Modified;
            db.SaveChanges();

            return isSuccess;
        }

        /// <summary>
        /// Maximums the bid price.
        /// </summary>
        /// <param name="ProductId">The product identifier.</param>
        /// <returns></returns>
        public float MaxBidPrice(int ProductId)
        {
            //            SELECT MAX(BidParticipantInformation.BidPrice)
            //FROM         AuctionInformation INNER JOIN
            //                      BidParticipantInformation ON AuctionInformation.AuctionInformationId = BidParticipantInformation.AuctionInformationId

            //                      where AuctionInformation.ProductId = 1
            var q = (from bp in db.BidParticipantInformations
                     join ai in db.AuctionInformations on bp.AuctionInformationId equals ai.AuctionInformationId
                     //select bp.BidPrice
                     select new
                     {
                         bp.BidPrice
                     }
                     //into bidPrice
                     //let maxActiveDate = bidPrice.Max(x => x.ActiveDate)
            );

            return 123;

            //throw new NotImplementedException();
        }


    }
}
