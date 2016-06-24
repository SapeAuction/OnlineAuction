using Auction.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.UI.Sevices
{
    //Seller or sells
    public interface IAuctionService
    {
        AuctionInformation GetAuctionInformationById(int userId);
        IEnumerable<AuctionInformation> GetAllAuctionInformation();
        int CreateAuctionInformation(AuctionInformation auctionInformationEntity);
        bool UpdateAuctionInformation(int id,AuctionInformation userEntity);
        bool DeleteAuctionInformation(int auctionId);
        bool saveLatestBidInformation(BidParticipantInformation bidInfo);
    }
}
