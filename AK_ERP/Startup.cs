using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AK_HR.Startup))]
namespace AK_HR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
