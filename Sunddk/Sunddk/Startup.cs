using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sunddk.Startup))]
namespace Sunddk
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
