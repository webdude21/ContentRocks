using Microsoft.Owin;

using Web;

[assembly: OwinStartup(typeof(Startup))]

namespace Web
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}