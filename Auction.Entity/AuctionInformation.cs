using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "The Start Date field is required.")]
        [DataType(DataType.Date)]
        public System.DateTime BidStartDateTime { get; set; }
        [DataType(DataType.Date)]

        [Required(ErrorMessage = "The End Date field is required.")]
        public System.DateTime BidEndDateTime { get; set; }

        public string BidDescription { get; set; }

        [Required(ErrorMessage = "The Base Price field is required.")]
        public decimal BidBasePrice { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<BidParticipantInformation> BidParticipantInformations { get; set; }
    }
}
