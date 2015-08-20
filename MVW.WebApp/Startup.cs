using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVW.WebApp.Startup))]
namespace MVW.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
