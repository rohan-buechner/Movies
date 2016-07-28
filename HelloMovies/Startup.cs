using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelloMovies.Startup))]
namespace HelloMovies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //configuration goes here
        }
    }
}
