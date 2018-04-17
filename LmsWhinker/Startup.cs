using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LmsWhinker.Startup))]
namespace LmsWhinker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
