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
        [HttpGet]
        [ActionName("GetUsers")]
        public HttpResponseMessage Get()
       {
            try
            {
                IEnumerable<User> listUser = _repository.GetAllUsers();
                if (listUser != null && listUser.Count() > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, listUser);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Users not found");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // GET: api/User/5
        [HttpGet]
        [Route("api/User/Getname/{userName}")]
        public HttpResponseMessage  Get(string userName)
        {
            try
            {
                User objUser = _repository.GetUserById(userName);
                if (objUser != null)
                    return Request.CreateResponse(HttpStatusCode.OK, objUser);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Users are Available");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        // POST: api/User
        [HttpPost]
        [ActionName("CreateUser")]
        public HttpResponseMessage Post([FromBody]User userEntity)
        {
           try
            {
                if (userEntity != null)
                {
                    if (_repository.CreateUser(userEntity) > 0)
                        return Request.CreateResponse(HttpStatusCode.OK);
                    else
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                }
                else
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/User/5
        [HttpDelete]
        [ActionName("DelteUser")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                if (_repository.DeleteUser(id))
                    return Request.CreateResponse(HttpStatusCode.OK);
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            { throw ex; }
        }

        // GET: api/User/5
        [HttpGet]
        [Route("api/User/IsValidUser/{userName}/{userPassword}")]
        public HttpResponseMessage IsValidUser(string userName, string userPassword)
        {
            try
            {
                User objUser = _repository.IsValidUser(userName, userPassword);
                if (objUser != null)
                    return Request.CreateResponse(HttpStatusCode.OK, objUser);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Users are Available");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
