using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibraryUI.Startup))]
namespace LibraryUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
