using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RashahlyKtab.Startup))]
namespace RashahlyKtab
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
