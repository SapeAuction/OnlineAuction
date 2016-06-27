using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Entity;
namespace Auction.UI.Sevices
{
    public interface IProductService
    {
        Product GetProductById(int productId);
        IEnumerable<Product> GetAllProducts();
        int CreateProduct(Product productEntity);
        bool UpdateUProduct(int usproductId, Product productEntity);
        bool DeleteProduct(int productId);
    }
}
