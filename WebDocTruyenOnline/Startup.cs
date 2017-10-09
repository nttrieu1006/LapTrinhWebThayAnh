using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebDocTruyenOnline.Startup))]
namespace WebDocTruyenOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
