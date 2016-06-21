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
        public int CreateBidParticipantInformation(BidParticipantInformation bidParticipantInformationEntity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBidParticipantInformation(BidParticipantInformation bidParticipantInformationEntity)
        {
            throw new NotImplementedException();
        }

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
            throw new NotImplementedException();
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
