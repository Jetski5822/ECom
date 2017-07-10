using Microsoft.AspNetCore.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace ECom.InMemoryStore
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<InMemorySupplierDataStore>();
        }
    }
}
