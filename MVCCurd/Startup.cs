using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCCurd.Startup))]
namespace MVCCurd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
