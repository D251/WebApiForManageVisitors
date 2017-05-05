using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApiForWorkPermitSystem.Startup))]
namespace WebApiForWorkPermitSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
