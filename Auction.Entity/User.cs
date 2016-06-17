using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Entity
{
    public class User
    {
        public User()
        {
            this.AuctionInformations = new HashSet<AuctionInformation>();
            this.BidParticipantInformations = new HashSet<BidParticipantInformation>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public virtual ICollection<AuctionInformation> AuctionInformations { get; set; }
        public virtual ICollection<BidParticipantInformation> BidParticipantInformations { get; set; }
    }
}
