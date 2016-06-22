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

        public bool CreateAuctionInformation(AuctionInformation auctionInformationEntity)
        {
            //auctionInformationEntity.Product = null;


            try
            {
                auctionInformationEntity.Product = null;
                db.AuctionInformations.Add(auctionInformationEntity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool DeleteAuctionInformation(int id)
        {
            try
            {

                AuctionInformation auctionObj = (from auc in db.AuctionInformations
                                                 where auc.AuctionInformationId == id
                                                 select auc).FirstOrDefault();

                if ((auctionObj != null) && (auctionObj.BidEndDateTime > DateTime.Now))
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
                                                     Product = new Product
                                                     {
                                                         ProductName = x.productObj.ProductName,
                                                         ProductDescription = x.productObj.ProductDescription,
                                                         ProductImageUrl = x.productObj.ProductImageUrl
                                                     }

                                                 }).OrderByDescending(t => t.BidStartDateTime).Take(20).ToList<AuctionInformation>();

                return AuctionInformationDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public IEnumerable<AuctionInformation> GetAllAuctionInformationByID(int id)
        {

            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var AuctionInformationDetails = (from auctionObj in db.AuctionInformations
                                                 join productObj in db.Products
                                                 on auctionObj.ProductId equals productObj.ProductId
                                                 where auctionObj.CreatedByUserId == id
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
                                                     Product = new Product
                                                     {
                                                         ProductName = x.productObj.ProductName,
                                                         ProductDescription = x.productObj.ProductDescription,
                                                         ProductImageUrl = x.productObj.ProductImageUrl,
                                                         ProductType=x.productObj.ProductType,
                                                         ProductTypeId=x.productObj.ProductTypeId                                                      
                                                     }

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
                                                             Product = new Product
                                                             {
                                                                 ProductName = x.productObj.ProductName,
                                                                 ProductDescription = x.productObj.ProductDescription,
                                                                 ProductImageUrl = x.productObj.ProductImageUrl,
                                                                 ProductTypeId=x.productObj.ProductTypeId
                                                             }
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
                   auctionObj.Product = userEntity.Product;
                    auctionObj.ProductId = userEntity.ProductId;
                    auctionObj.BidStartDateTime = userEntity.BidStartDateTime;
                    auctionObj.BidEndDateTime = userEntity.BidEndDateTime;
                    auctionObj.BidBasePrice = userEntity.BidBasePrice;
                    auctionObj.BidDescription = userEntity.BidDescription;
                    db.Entry(auctionObj).State = System.Data.EntityState.Modified;
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
