using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WorkRequests.Startup))]
namespace WorkRequests
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
