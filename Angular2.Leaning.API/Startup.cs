using Microsoft.Owin;
using Owin;
using Startup = Angular2.Leaning.API.Startup;

[assembly: OwinStartup(typeof(Startup))]

namespace Angular2.Leaning.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
