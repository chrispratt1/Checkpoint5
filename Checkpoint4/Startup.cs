using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Checkpoint4.Startup))]
namespace Checkpoint4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
