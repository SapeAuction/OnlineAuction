using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Entity;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace Auction.Sevices
{
    public class UserService : IUserService
    {
        //API Call 
        private List<Auction.Entity.User> userobj;
        public List<Auction.Entity.User> GetUsers()
        {

            using (var client = new HttpClient())

            {
                //JavaScriptSerializer json_serializer = new JavaScriptSerializer();               

                ////http://10.209.41.40/AuctionWebApi/api/user
                //client.BaseAddress = new Uri("http://10.209.41.40");
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //var response = client.GetAsync("AuctionWebApi/api/User").Result;
                //if (response.IsSuccessStatusCode)

                //{

                //     var uso = response.Content.ReadAsStringAsync().Result;
                //     object  Us =  json_serializer.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                //    userobj = (Auction.Entity.User)Us;
                //}


                //return uso;
              //  string url = "http://10.209.41.40/AuctionWebApi/api/user";

                client.BaseAddress = new Uri("http://10.209.41.40");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //  HttpResponseMessage responseMessage = await client.GetAsync(url);
                HttpResponseMessage responseMessage = client.GetAsync("AuctionWebApi/api/User").Result;

                if (responseMessage.IsSuccessStatusCode)

                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    userobj = JsonConvert.DeserializeObject<List<User>>(responseData);
                }

                return userobj;

            }
        }

        public int CreateUser(User userEntity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Auction.Entity.User> GetAllUsers()
        {
            using (var client = new HttpClient())

            {

                client.BaseAddress = new Uri("http://10.209.41.40");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //  HttpResponseMessage responseMessage = await client.GetAsync(url);
                HttpResponseMessage responseMessage = client.GetAsync("AuctionWebApi/api/User").Result;

                if (responseMessage.IsSuccessStatusCode)

                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    userobj = JsonConvert.DeserializeObject<List<User>>(responseData);
                }
            }
                return userobj;
        }

        public User GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(int userId, User userEntity)
        {
            throw new NotImplementedException();
        }
    }
}
