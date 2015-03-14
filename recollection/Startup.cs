using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(recollection.Startup))]
namespace recollection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
