using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Entity
{
    public class BidParticipantInformation
    {
        public BidParticipantInformation()
        {
            this.AuctionInformation = new AuctionInformation();
        }

        public int BidParticipantInformationId { get; set; }
        public int UserId { get; set; }
        public int AuctionInformationId { get; set; }
        public decimal BidPrice { get; set; }
        public System.DateTime BidCreationDateTime { get; set; }

        public virtual AuctionInformation AuctionInformation { get; set; }
        public virtual User User { get; set; }
    }
}
