using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InsuranceQuote.Startup))]
namespace InsuranceQuote
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
