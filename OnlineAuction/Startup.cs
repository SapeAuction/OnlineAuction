using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineAuction.Startup))]
namespace OnlineAuction
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
