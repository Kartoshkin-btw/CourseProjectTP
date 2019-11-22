using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Course_progect_TP.Startup))]
namespace Course_progect_TP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
