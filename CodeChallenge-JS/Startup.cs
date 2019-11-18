using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeChallenge_JS.Startup))]
namespace CodeChallenge_JS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
