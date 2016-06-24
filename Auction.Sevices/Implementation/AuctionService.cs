using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Entity;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Auction.UI.Sevices;
using log4net;

namespace Auction.Sevices
{
    public class AuctionService : IAuctionService
    {
        private List<Auction.Entity.AuctionInformation> _auctionInformationList;
        private static readonly ILog logger = LogManager.GetLogger(typeof(string));

        /// <summary>
        /// Creates the auction information.
        /// </summary>
        /// <param name="auctionInformationEntity">The auction information entity.</param>
        /// <returns></returns>
        public int CreateAuctionInformation(AuctionInformation auctionInformationEntity)
        {
            try
            {
                int result = default(int);
                using (var client = new HttpClient())
                {
                    string resourceAddress = "http://localhost:58167/api/auction";
                    if (auctionInformationEntity != null)
                    {
                        string postBody = JsonConvert.SerializeObject(auctionInformationEntity);
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage wcfResponse = client.PostAsync(resourceAddress, new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                        if (wcfResponse.IsSuccessStatusCode)
                            result = 1;
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

        /// <summary>
        /// Deletes the auction information.
        /// </summary>
        /// <param name="auctionId">The auction identifier.</param>
        /// <returns></returns>
        public bool DeleteAuctionInformation(int auctionId)
        {
            bool status = true; 
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:58167/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage responseMessage = client.DeleteAsync("/api/Auction/" + auctionId).Result;

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        status = true;
                    }
                    else
                    {

                        status = false;
                    }
                    return status;
                }
            }
            catch ( Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
            
        }

        /// <summary>
        /// Gets all auction information.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AuctionInformation> GetAllAuctionInformation()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:58167/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    
                    HttpResponseMessage responseMessage = client.GetAsync("/api/Auction").Result;

                    if (responseMessage.IsSuccessStatusCode)

                    {
                        var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                        _auctionInformationList = JsonConvert.DeserializeObject<List<AuctionInformation>>(responseData);
                    }
                }
                return _auctionInformationList;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }

        }

        /// <summary>
        /// Gets the current sales.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SP_GetMaxBidUserDetails_Result> GetCurrentSales()
        {
            IEnumerable<SP_GetMaxBidUserDetails_Result> salesDetails = new List<SP_GetMaxBidUserDetails_Result>();

            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:58167/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage responseMessage = client.GetAsync("/api/Auction").Result;

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                        salesDetails = JsonConvert.DeserializeObject<IEnumerable<SP_GetMaxBidUserDetails_Result>>(responseData);
                    }
                }

                return salesDetails;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Gets the auction information by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public AuctionInformation GetAuctionInformationById(int userId)
        {
            try
            {
                AuctionInformation _auctionInformation = null;
                using (var client = new HttpClient())

                {
                    client.BaseAddress = new Uri("http://localhost:58167/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                   
                    HttpResponseMessage responseMessage = client.GetAsync("/api/Auction/" + userId).Result;

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                        _auctionInformation = JsonConvert.DeserializeObject<AuctionInformation>(responseData);
                    }
                }
                return _auctionInformation;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Updates the auction information.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="userEntity">The user entity.</param>
        /// <returns></returns>
        public bool UpdateAuctionInformation(int id,AuctionInformation userEntity)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string resourceAddress = "http://localhost:58167/api/auction/"+id;
                    if (userEntity != null)
                    {
                        string postBody = JsonConvert.SerializeObject(userEntity);
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage wcfResponse = client.PutAsync(resourceAddress, new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                        if (wcfResponse.IsSuccessStatusCode)
                        {
                        }
                    }
                   
                }
                return true; 
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Saves the latest bid information.
        /// </summary>
        /// <param name="bidInfo">The bid information.</param>
        /// <returns></returns>
        public bool saveLatestBidInformation(BidParticipantInformation bidInfo)
        {
            bool status = true;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:58167");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string postBody = JsonConvert.SerializeObject(bidInfo);
                    HttpResponseMessage apiResponse = client.PostAsync("api/Bid", new StringContent(postBody, Encoding.UTF8, "application/json")).Result;

                    if (apiResponse.IsSuccessStatusCode)
                    {
                        status = true;
                    }
                    else { status = false; }
                }
                return status;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }
    }
}
