using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Auction.WebApi.Sevices.Interfaces;
using Auction.WebApi.Sevices.Implementations;


namespace AuctionWebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserService, UserService >();
            container.RegisterType<IAuctionService, AuctionService>();
            container.RegisterType<IBidService, BidService>();
            container.RegisterType<IProductService, ProductService>();
            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}