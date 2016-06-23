using Auction.Entity;
using System.Collections.Generic;

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
