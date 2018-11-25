using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Challenge4_Practice.Startup))]
namespace Challenge4_Practice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
