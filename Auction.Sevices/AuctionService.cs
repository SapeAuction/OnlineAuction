using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Entity;

namespace Auction.Sevices
{
    public class AuctionService : IAuctionService
    {
        int IAuctionService.CreateAuctionInformation(AuctionInformation auctionInformationEntity)
        {
            throw new NotImplementedException();
        }

        bool IAuctionService.DeleteAuctionInformation(AuctionInformation userEntity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<AuctionInformation> IAuctionService.GetAllAuctionInformation()
        {
            throw new NotImplementedException();
        }

        AuctionInformation IAuctionService.GetAuctionInformationById(int userId)
        {
            throw new NotImplementedException();
        }

        bool IAuctionService.UpdateAuctionInformation(AuctionInformation userEntity)
        {
            throw new NotImplementedException();
        }
    }
}
