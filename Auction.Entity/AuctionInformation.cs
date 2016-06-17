using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Entity
{
    public class AuctionInformation
    {
        public AuctionInformation()
        {
            this.BidParticipantInformations = new HashSet<BidParticipantInformation>();
        }

        public int AuctionInformationId { get; set; }
        public int ProductId { get; set; }
        public int CreatedByUserId { get; set; }
        public System.DateTime BidStartDateTime { get; set; }
        public System.DateTime BidEndDateTime { get; set; }
        public string BidDescription { get; set; }
        public decimal BidBasePrice { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<BidParticipantInformation> BidParticipantInformations { get; set; }
    }
}
