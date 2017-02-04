using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Recomida.WebApp.Startup))]
namespace Recomida.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
