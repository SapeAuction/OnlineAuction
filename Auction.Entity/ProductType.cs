using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Entity
{
    public class ProductType
    {
        public ProductType()
        {
            this.Products = new HashSet<Product>();
        }

        public int ProductTypeId { get; set; }
        public string ProductTypeDescription { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
