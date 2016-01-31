using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SkyTechTest.Startup))]
namespace SkyTechTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
