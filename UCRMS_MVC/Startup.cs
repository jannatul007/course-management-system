using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UCRMS_MVC.Startup))]
namespace UCRMS_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
