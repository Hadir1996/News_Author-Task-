using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewsAuthorTask.Startup))]
namespace NewsAuthorTask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
