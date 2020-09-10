using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vid.Startup))]
namespace Vid
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
