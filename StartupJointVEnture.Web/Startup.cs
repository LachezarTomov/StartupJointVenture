using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StartupJointVEnture.Web.Startup))]
namespace StartupJointVEnture.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
