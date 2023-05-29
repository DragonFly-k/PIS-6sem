using Microsoft.Owin;
using MvcIdentityLab;
using Owin;

[assembly: OwinStartupAttribute(typeof(Startup))]

namespace MvcIdentityLab
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app); 
        }
    }
}