using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Entity;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;


namespace Auction.UI.Sevices
{
    public class BidService : IBidService
    {
        private List<Auction.Entity.BidParticipantInformation> _bidParticipentList ;

        /// <summary>
        /// Creates the bid participant information.
        /// </summary>
        /// <param name="bidParticipantInformationEntity">The bid participant information entity.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int CreateBidParticipantInformation(BidParticipantInformation bidParticipantInformationEntity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBidParticipantInformation(BidParticipantInformation bidParticipantInformationEntity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all bid participant information.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BidParticipantInformation> GetAllBidParticipantInformation()
        {
            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri("http://localhost:58167/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //  HttpResponseMessage responseMessage = await client.GetAsync(url);
                HttpResponseMessage responseMessage = client.GetAsync("api/Bid").Result;

                if (responseMessage.IsSuccessStatusCode)

                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    _bidParticipentList = JsonConvert.DeserializeObject<List<BidParticipantInformation>>(responseData);
                }
            }
            return _bidParticipentList;
        }

        /// <summary>
        /// Gets all bid participant information1.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BidParticipantInformation>> GetAllBidParticipantInformation1()
        {
            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri("http://localhost:57043/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //  HttpResponseMessage responseMessage = await client.GetAsync(url);
                HttpResponseMessage responseMessage = await client.GetAsync("AuctionWebApi/api/Bid");

                if (responseMessage.IsSuccessStatusCode)

                {
                    //_bidParticipentList = await responseMessage.Content.ReadAsAsync<>();
//                    List<BidParticipantInformation> lst = await responseMessage.Content.ReadAsAsync
                    //_bidParticipentList = JsonConvert.DeserializeObject<List<BidParticipantInformation>>(responseData);
                }
            }
            return _bidParticipentList;
        }

        public BidParticipantInformation GetBidParticipantInformationById(int userId)
        {

            try
            {
                BidParticipantInformation _auctionInformation = null;
                using (var client = new HttpClient())

                {
                    client.BaseAddress = new Uri("http://localhost:58167/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    HttpResponseMessage responseMessage = client.GetAsync("/api/Bid/" + userId).Result;

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                        _auctionInformation = JsonConvert.DeserializeObject<BidParticipantInformation>(responseData);
                    }
                }
                return _auctionInformation;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public float MaxBidPrice(int ProductId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBidParticipantInformation(BidParticipantInformation userEntity)
        {
            throw new NotImplementedException();
        }
    }
}
