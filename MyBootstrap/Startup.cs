using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyBootstrap.Startup))]
namespace MyBootstrap
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
