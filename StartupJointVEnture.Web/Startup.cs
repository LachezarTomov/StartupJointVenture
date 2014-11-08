using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StartupJointVenture.Web.Startup))]
namespace StartupJointVenture.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
