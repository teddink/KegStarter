using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KegStarter.Startup))]
namespace KegStarter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
