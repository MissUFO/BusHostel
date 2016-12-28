using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusHostel.Web.Startup))]
namespace BusHostel.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
