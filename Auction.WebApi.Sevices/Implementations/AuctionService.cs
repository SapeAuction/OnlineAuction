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
    public class AuctionService : IAuctionService
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(string));
        private AuctionDBEntities db = new AuctionDBEntities();

        /// <summary>
        /// Creates the auction information.
        /// </summary>
        /// <param name="auctionInformationEntity">The auction information entity.</param>
        /// <returns></returns>
        public bool CreateAuctionInformation(AuctionInformation auctionInformationEntity)
        {
            try
            {
                auctionInformationEntity.BidStartDateTime = DateTime.Now;
                // auctionInformationEntity.Product = null;
                db.AuctionInformations.Add(auctionInformationEntity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }

        }

        /// <summary>
        /// Deletes the auction information.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool DeleteAuctionInformation(int id)
        {
            try
            {
                AuctionInformation auctionObj = (from auc in db.AuctionInformations
                                                 where auc.AuctionInformationId == id
                                                 select auc).FirstOrDefault();

                if ((auctionObj != null))
                {
                    auctionObj.BidEndDateTime = DateTime.Now;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }

            return false;
        }

        /// <summary>
        /// Gets all auction information.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SP_GetMaxBidUserDetails_Result> GetAllAuctionInformation()
        {
            IEnumerable<SP_GetMaxBidUserDetails_Result> salesDetails = null;

            try
            {
                db.Configuration.ProxyCreationEnabled = false;

                salesDetails = db.SP_GetMaxBidUserDetails().AsEnumerable<SP_GetMaxBidUserDetails_Result>();

                //var AuctionInformationDetails = (from auctionObj in db.AuctionInformations
                //                                 join productObj in db.Products
                //                                 on auctionObj.ProductId equals productObj.ProductId
                //                                 select new { auctionObj, productObj }).ToList().Select(x => new AuctionInformation
                //                                 {
                //                                     AuctionInformationId = x.auctionObj.AuctionInformationId,
                //                                     BidBasePrice = x.auctionObj.BidBasePrice,
                //                                     BidDescription = x.auctionObj.BidDescription,
                //                                     BidEndDateTime = x.auctionObj.BidEndDateTime,
                //                                     BidParticipantInformations = x.auctionObj.BidParticipantInformations,
                //                                     BidStartDateTime = x.auctionObj.BidStartDateTime,
                //                                     CreatedByUserId = x.auctionObj.CreatedByUserId,
                //                                     ProductId = x.auctionObj.ProductId,
                //                                     User = x.auctionObj.User,
                //                                     Product = new Product
                //                                     {
                //                                         ProductName = x.productObj.ProductName,
                //                                         ProductDescription = x.productObj.ProductDescription,
                //                                         ProductImageUrl = x.productObj.ProductImageUrl
                //                                     }

                //                                 }).OrderByDescending(t => t.BidStartDateTime).Take(20).ToList<AuctionInformation>();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }

            return salesDetails;
        }


        /// <summary>
        /// Gets all auction information by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
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
                logger.Error(ex.Message);
                throw ex;
            }

        }

        /// <summary>
        /// Gets the auction information by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
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
                logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Updates the auction information.
        /// </summary>
        /// <param name="userEntity">The user entity.</param>
        /// <returns></returns>
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
                   // auctionObj.BidStartDateTime = userEntity.BidStartDateTime;
                   // auctionObj.BidEndDateTime = userEntity.BidEndDateTime;
                    auctionObj.BidBasePrice = userEntity.BidBasePrice;
                    auctionObj.BidDescription = userEntity.BidDescription;
                    db.Entry(auctionObj).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }

            return false;

        }

    }
}
