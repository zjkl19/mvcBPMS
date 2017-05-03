using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvcBPMS.Startup))]
namespace mvcBPMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
