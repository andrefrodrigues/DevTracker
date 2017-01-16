using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DevTracker.Startup))]
namespace DevTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
