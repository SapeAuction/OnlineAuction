using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Entity;
using Auction.WebApi.Sevices.Interfaces;
using Auction.WebApi.DataModel;
using log4net;

namespace Auction.WebApi.Sevices.Implementations
{
    public class ProductService : IProductService
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(string));
        private AuctionDBEntities db = new AuctionDBEntities();

        /// <summary>
        /// Creates the product.
        /// </summary>
        /// <param name="productEntity">The product entity.</param>
        /// <returns></returns>
        public int CreateProduct(Product productEntity)
        {
            db.Configuration.ProxyCreationEnabled = false;
            try
            {
                if (db.Products.Add(productEntity) != null)
                    db.SaveChanges();
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }

            return productEntity.ProductId;
        }

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns></returns>
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
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }

        }

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
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
                logger.Error(ex.Message);
                throw ex;
            }
        }

        public bool UpdateUProduct(int usproductId, Product productEntity)
        {
            throw new NotImplementedException();
        }
    }
}
