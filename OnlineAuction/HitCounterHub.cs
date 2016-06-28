using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Auction.Sevices;
using Auction.Entity;
using Auction.UI.Sevices;

namespace OnlineAuction
{

    [HubName("hitCounter")]
    public class HitCounterHub : Hub
    {

        // private static int _hitCount = 0;
        public void RecordHit(int UserId, int AuctionInformationId, int bidCollection)
        {
            BidParticipantInformation placeBidInfo = new BidParticipantInformation
            {
                UserId = Convert.ToInt32(UserId),
                AuctionInformationId = Convert.ToInt32(AuctionInformationId),
                BidPrice = Convert.ToDecimal(bidCollection),
                BidCreationDateTime = DateTime.Now,
                AuctionInformation = null
            };

            AuctionService _auctionService = new AuctionService();
            _auctionService.saveLatestBidInformation(placeBidInfo);
            this.Clients.All.onHitRecorded(bidCollection);


        }
    }
    
}


