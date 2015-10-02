using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InvestorAdviser.Startup))]
namespace InvestorAdviser
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
