using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Entity;
using Auction.WebApi.Sevices.Interfaces;

namespace Auction.WebApi.Sevices.Implementations
{
    public class ProductService : IProductService
    {
        public int CreateProduct(Product productEntity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public User GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUProduct(int usproductId, Product productEntity)
        {
            throw new NotImplementedException();
        }
    }
}
