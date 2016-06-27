using System;
using System.Collections.Generic;
using System.Text;
using Auction.Entity;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Auction.UI.Sevices;

namespace Auction.Sevices
{
    public class AuctionService : IAuctionService
    {

        private List<Auction.Entity.AuctionInformation> _auctionInformationList;
       
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
                throw ex;
            }
        }

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
            catch
            {
                throw new Exception();
            }
        }

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
            catch
            {
                throw new Exception();
            }
            
        }

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
            catch {
                throw new Exception();
            }
        }

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
            catch
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Updates the auction information.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="userEntity">The user entity.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
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
            catch
            {
                throw new NotImplementedException();
            }
        }

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
            catch
            {

                throw new Exception();
            }
        }

    }
}
