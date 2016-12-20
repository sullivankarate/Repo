using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Karate.Startup))]
namespace Karate
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
