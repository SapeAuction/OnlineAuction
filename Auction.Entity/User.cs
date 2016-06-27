using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]

        public string Password { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public string EmailId { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public virtual ICollection<AuctionInformation> AuctionInformations { get; set; }
        public virtual ICollection<BidParticipantInformation> BidParticipantInformations { get; set; }
    }
}
