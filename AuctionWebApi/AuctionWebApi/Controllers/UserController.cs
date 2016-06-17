using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Auction.WebApi.Sevices.Interfaces;
using Auction.Entity;

namespace AuctionWebApi.Controllers
{
    public class UserController : ApiController
    {        
        private IUserService _repository;

        public UserController(IUserService repository)
        {
            _repository = repository;
        }

        // GET: api/User
        public IEnumerable<User> Get()
        {
            return _repository.GetAllUsers();

        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
