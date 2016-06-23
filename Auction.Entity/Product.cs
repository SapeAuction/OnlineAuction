using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Entity
{
    public class Product
    {
        public Product()
        {
            this.AuctionInformations = new HashSet<AuctionInformation>();
        }

        public int ProductId { get; set; }

        [Required(ErrorMessage = "The Product field is required.")]
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "The Product Image field is required.")]
        public string ProductImageUrl { get; set; }

        [Required(ErrorMessage = "The Product Type field is required.")]
        public int ProductTypeId { get; set; }
        public Nullable<bool> ProductStatus { get; set; }

        public virtual ICollection<AuctionInformation> AuctionInformations { get; set; }
        public virtual ProductType ProductType { get; set; }
    }
}
