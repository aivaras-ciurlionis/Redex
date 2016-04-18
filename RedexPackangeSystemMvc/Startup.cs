using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RedexPackangeSystemMvc.Startup))]
namespace RedexPackangeSystemMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
