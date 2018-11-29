using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TercihRobotumBuSonOlsun.Startup))]
namespace TercihRobotumBuSonOlsun
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
