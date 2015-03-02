using Microsoft.Owin;
using Owin;
using WebApplication1;

[assembly: OwinStartup(typeof (Startup))]

namespace WebApplication1 {
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}