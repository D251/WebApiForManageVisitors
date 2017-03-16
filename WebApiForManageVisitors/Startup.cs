using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApiForManageVisitors.Startup))]
namespace WebApiForManageVisitors
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
