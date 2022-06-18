using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ElevatorSystem.Admin.Startup))]
namespace ElevatorSystem.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
