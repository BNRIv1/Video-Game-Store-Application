using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IT_MVC_Proekt.Startup))]
namespace IT_MVC_Proekt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
