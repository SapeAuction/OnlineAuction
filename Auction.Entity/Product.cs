using System;
using System.Collections.Generic;
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
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImageUrl { get; set; }
        public int ProductTypeId { get; set; }
        public Nullable<bool> ProductStatus { get; set; }

        public virtual ICollection<AuctionInformation> AuctionInformations { get; set; }
        public virtual ProductType ProductType { get; set; }
    }
}
