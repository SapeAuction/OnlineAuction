using Auction.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.WebApi.Sevices.Interfaces
{
    //Seller or sells
    public interface IAuctionService
    {
        AuctionInformation GetAuctionInformationById(int userId);
        IEnumerable<AuctionInformation> GetAllAuctionInformation();
        IEnumerable<AuctionInformation> GetAllAuctionInformationByID(int id);
        bool CreateAuctionInformation(AuctionInformation auctionInformationEntity);
        bool UpdateAuctionInformation(AuctionInformation userEntity);
        bool DeleteAuctionInformation(int id);
    }
}
