using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Template.Startup))]
namespace MVC_Template
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
