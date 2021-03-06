using System.IO;
using System.Reflection;
using Lamar;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Mmu.CleanArchitecture.WebApi.Infrastructure.Initialization;

namespace Mmu.CleanArchitecture.WebApi
{
    public class Startup
    {
        public Startup()
        {
            var runDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            var builder = new ConfigurationBuilder()
                .SetBasePath(runDir)
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        private IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app)
        {
            AppInitialization.InitializeApplication(app);
        }

        public void ConfigureContainer(ServiceRegistry services)
        {
            ServiceInitialization.InitializeServices(services, Configuration);
        }
    }
}