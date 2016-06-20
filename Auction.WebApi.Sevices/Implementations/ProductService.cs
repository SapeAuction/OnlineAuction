using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Entity;
using Auction.WebApi.Sevices.Interfaces;
using Auction.WebApi.DataModel;


namespace Auction.WebApi.Sevices.Implementations
{
    public class ProductService : IProductService
    {

        private AuctionDBEntities db = new AuctionDBEntities();
        public int CreateProduct(Product productEntity)
        {
            db.Configuration.ProxyCreationEnabled = false;
            int createdStatus = default(int);
            try
            {
                if(db.Products.Add(productEntity)!=null)
                    createdStatus = db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return createdStatus;
        }

        public bool DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                IEnumerable<Product> ProductList = (from product1 in db.Products
                                                    select product1).ToList().Select(p => new Product
                                                    {
                                                        ProductId = p.ProductId,
                                                        ProductName = p.ProductName,
                                                        ProductDescription = p.ProductDescription,
                                                        ProductImageUrl = p.ProductImageUrl,
                                                        ProductTypeId = p.ProductTypeId,
                                                        ProductStatus = p.ProductStatus
                                                    }).ToList<Product>();

                return ProductList;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public Product GetProductById(int productId)
        {
            try
            {
                Product _Product = (from ProdObj in db.Products
                                    where ProdObj.ProductId == productId
                                    select new { ProdObj}).ToList().Select(p => new Product
                                    {
                                        ProductId = p.ProdObj.ProductId,
                                        ProductName = p.ProdObj.ProductName,
                                        ProductDescription = p.ProdObj.ProductDescription,
                                        ProductImageUrl = p.ProdObj.ProductImageUrl,
                                        ProductTypeId = p.ProdObj.ProductTypeId,
                                        ProductStatus = p.ProdObj.ProductStatus
                                    }).FirstOrDefault();
                return _Product;  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateUProduct(int usproductId, Product productEntity)
        {
            throw new NotImplementedException();
        }
    }
}
