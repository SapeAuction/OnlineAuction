using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Entity;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using log4net;

namespace Auction.UI.Sevices
{
    public class ProductService : IProductService
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(string));
        private List<Auction.Entity.Product> _ProdList;
        private Product _Prod;

        /// <summary>
        /// Creates the product.
        /// </summary>
        /// <param name="productEntity">The product entity.</param>
        /// <returns></returns>
        public int CreateProduct(Product productEntity)
        {
            try
            {
                int result = default(int);
                using (var client = new HttpClient())
                {
                    string resourceAddress = "http://localhost:58167/api/product";
                    if (productEntity != null)
                    {
                        string postBody = JsonConvert.SerializeObject(productEntity);
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage wcfResponse = client.PostAsync(resourceAddress, new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                        result = Convert.ToInt32(wcfResponse.Content.ReadAsStringAsync().Result);

                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }

        }

        public bool DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        public Auction.Entity.Product GetProductById(int productId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:58167/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //  HttpResponseMessage responseMessage = await client.GetAsync(url);
                HttpResponseMessage responseMessage = client.GetAsync("api/product/1").Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    _Prod = JsonConvert.DeserializeObject<Product>(responseData);
                }
            }
            return _Prod;
        }

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetAllProducts()
        {            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:58167/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //  HttpResponseMessage responseMessage = await client.GetAsync(url);
                HttpResponseMessage responseMessage = client.GetAsync("api/product").Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    _ProdList = JsonConvert.DeserializeObject<List<Product>>(responseData);
                }
            }
            return _ProdList;
        }

        /// <summary>
        /// Updates the u product.
        /// </summary>
        /// <param name="usproductId">The usproduct identifier.</param>
        /// <param name="productEntity">The product entity.</param>
        /// <returns></returns>
        public bool UpdateUProduct(int usproductId, Product productEntity)
        {
            try
            {
                int result = default(int);
                using (var client = new HttpClient())
                {
                    string resourceAddress = "http://localhost:58167/api/product";
                    if (productEntity != null)
                    {
                        string postBody = JsonConvert.SerializeObject(productEntity);
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage wcfResponse = client.PostAsync(resourceAddress, new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                        result = Convert.ToInt32(wcfResponse.Content.ReadAsStringAsync().Result);

                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }

        }
    }
}
