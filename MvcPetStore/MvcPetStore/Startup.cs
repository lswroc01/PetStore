using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcPetStore.Startup))]
namespace MvcPetStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
