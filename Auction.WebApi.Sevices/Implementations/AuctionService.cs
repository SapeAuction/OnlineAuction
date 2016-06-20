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
    public class AuctionService : IAuctionService
    {

        private AuctionDBEntities db = new AuctionDBEntities();

        public int CreateAuctionInformation(AuctionInformation auctionInformationEntity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAuctionInformation(int id)
        {
            try
            {

                AuctionInformation auctionObj = (from auc in db.AuctionInformations
                                                 where auc.AuctionInformationId == id
                                                 select auc).FirstOrDefault();

                if (auctionObj != null)
                {
                    auctionObj.BidEndDateTime = DateTime.Now;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public IEnumerable<AuctionInformation> GetAllAuctionInformation()
        {

            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var AuctionInformationDetails = (from auctionObj in db.AuctionInformations
                                                 join productObj in db.Products
                                                 on auctionObj.ProductId equals productObj.ProductId
                                                 select new { auctionObj, productObj }).ToList().Select(x => new AuctionInformation
                                                 {
                                                     AuctionInformationId = x.auctionObj.AuctionInformationId,
                                                     BidBasePrice = x.auctionObj.BidBasePrice,
                                                     BidDescription = x.auctionObj.BidDescription,
                                                     BidEndDateTime = x.auctionObj.BidEndDateTime,
                                                     BidParticipantInformations = x.auctionObj.BidParticipantInformations,
                                                     BidStartDateTime = x.auctionObj.BidStartDateTime,
                                                     CreatedByUserId = x.auctionObj.CreatedByUserId,
                                                     ProductId = x.auctionObj.ProductId,
                                                     User = x.auctionObj.User,
                                                     Product = new Product { ProductName = x.productObj.ProductName }

                                                 }).OrderByDescending(t => t.BidStartDateTime).Take(20).ToList<AuctionInformation>();

                return AuctionInformationDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public AuctionInformation GetAuctionInformationById(int userId)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;

                AuctionInformation AuctionInformation = (from auctionObj in db.AuctionInformations
                                                         join productObj in db.Products
                                                         on auctionObj.ProductId equals productObj.ProductId
                                                         where auctionObj.AuctionInformationId == userId
                                                         select new { auctionObj, productObj }).ToList().Select(x => new AuctionInformation
                                                         {
                                                             AuctionInformationId = x.auctionObj.AuctionInformationId,
                                                             BidBasePrice = x.auctionObj.BidBasePrice,
                                                             BidDescription = x.auctionObj.BidDescription,
                                                             BidEndDateTime = x.auctionObj.BidEndDateTime,
                                                             BidParticipantInformations = x.auctionObj.BidParticipantInformations,
                                                             BidStartDateTime = x.auctionObj.BidStartDateTime,
                                                             CreatedByUserId = x.auctionObj.CreatedByUserId,
                                                             ProductId = x.auctionObj.ProductId,
                                                             User = x.auctionObj.User,
                                                             Product = new Product { ProductName = x.productObj.ProductName }
                                                         }).FirstOrDefault();

                return AuctionInformation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateAuctionInformation(AuctionInformation userEntity)
        {

            try
            {

                AuctionInformation auctionObj = (from auc in db.AuctionInformations
                                                 where auc.AuctionInformationId == userEntity.AuctionInformationId
                                                 select auc).FirstOrDefault();

                if (auctionObj != null)
                {

                    auctionObj.BidBasePrice = userEntity.BidBasePrice;
                    auctionObj.BidDescription = userEntity.BidDescription;
                    auctionObj.BidEndDateTime = userEntity.BidEndDateTime;
                    auctionObj.BidParticipantInformations = userEntity.BidParticipantInformations;
                    auctionObj.BidStartDateTime = userEntity.BidStartDateTime;
                    auctionObj.BidEndDateTime = DateTime.Now;

                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;





        }
    }
}
