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

        public bool DeleteAuctionInformation(AuctionInformation userEntity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuctionInformation> GetAllAuctionInformation()
        {

            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri("http://localhost:58167/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //  HttpResponseMessage responseMessage = await client.GetAsync(url);
                HttpResponseMessage responseMessage = client.GetAsync("/api/Auction").Result;

                if (responseMessage.IsSuccessStatusCode)

                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    _auctionInformationList = JsonConvert.DeserializeObject<List<AuctionInformation>>(responseData);
                }
            }
            return _auctionInformationList;

            throw new NotImplementedException();
        }

        public AuctionInformation GetAuctionInformationById(int userId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAuctionInformation(AuctionInformation userEntity)
        {
            throw new NotImplementedException();
        }
    }
}
