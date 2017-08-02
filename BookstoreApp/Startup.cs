using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookstoreApp.Startup))]
namespace BookstoreApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
