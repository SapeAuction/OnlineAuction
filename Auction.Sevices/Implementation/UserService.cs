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
using Newtonsoft.Json.Serialization;
using log4net;

namespace Auction.UI.Sevices
{
    public class UserService : IUserService
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(string));

        private List<Auction.Entity.User> userobj;

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns></returns>
        public List<Auction.Entity.User> GetUsers()
        {

            using (var client = new HttpClient())

            {
                 client.BaseAddress = new Uri("http://10.209.41.40");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = client.GetAsync("AuctionWebApi/api/User").Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    userobj = JsonConvert.DeserializeObject<List<User>>(responseData);
                }
                return userobj;

            }
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="userEntity">The user entity.</param>
        /// <returns></returns>
        public int CreateUser(User userEntity)
        {
            try
            {
                int result = default(int);
                using (var client = new HttpClient())
                {                  
                    string resourceAddress = "http://localhost:58167/api/user";
                    if (userEntity != null)
                    {
                        string postBody = JsonConvert.SerializeObject(userEntity);
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

        public bool DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public User GetUserById(string userName)
        {
            try
            {
                Auction.Entity.User objusr = new User();
                using (var client = new HttpClient())
                {
                    //http://localhost:58167/api/User/Getname/''dddd'
                    client.BaseAddress = new Uri("http://localhost:58167");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //  HttpResponseMessage responseMessage = await client.GetAsync(url);
                    HttpResponseMessage responseMessage = client.GetAsync("/api/User/Getname//" + userName).Result;

                    if (responseMessage.IsSuccessStatusCode)

                    {
                        var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                        objusr = JsonConvert.DeserializeObject<User>(responseData);
                        
                    }
                    else
                    {
                        objusr = null;
                    }

                    return objusr;
                }
               
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }

        }

        public bool UpdateUser(int userId, User userEntity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether [is valid user] [the specified user name].
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="userPassword">The user password.</param>
        /// <returns></returns>
        public User IsValidUser(string userName, string userPassword)
        {
            try
            {
                Auction.Entity.User objusr = new User();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:58167");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage responseMessage = client.GetAsync("/api/User/IsValidUser/" + userName + "/" + userPassword).Result;

                    if (responseMessage.IsSuccessStatusCode)

                    {
                        var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                        objusr = JsonConvert.DeserializeObject<User>(responseData);

                    }
                    else
                    {
                        objusr = null;
                    }

                    return objusr;
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
