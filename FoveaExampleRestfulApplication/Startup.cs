using Owin;

namespace FoveaExampleRestfulApplication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
        }
    }
}