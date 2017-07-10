using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Modules;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Orchard.Environment.Shell;
using Swashbuckle.AspNetCore.Swagger;

namespace ECom.Swagger
{
    public class Startup : StartupBase
    {
        private readonly IHostingEnvironment _hostingEnv;
        private readonly ShellSettingsWithTenants _ss;

        public Startup(IHostingEnvironment env,
            ShellSettingsWithTenants ss)
        {
            _hostingEnv = env;
            _ss = ss;
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.TryAddSingleton<IApiDescriptionGroupCollectionProvider, ApiDescriptionGroupCollectionProvider>();
            services.TryAddEnumerable(
                ServiceDescriptor.Transient<IApiDescriptionProvider, DefaultApiDescriptionProvider>());

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });

                options.DescribeAllEnumsAsStrings();

                options.DocInclusionPredicate((n, api) => _ss.Features.Contains(api.ActionDescriptor.RouteValues["area"]));

                foreach (var extension in _ss.Features)
                {
                    var path = Path.Combine(
                        _hostingEnv.ContentRootPath.Replace("ECom.Web", ""),
                        "ECom.Modules",
                        extension,
                        "bin",
                        "Debug",
                        "netstandard1.6",
                        $"{extension}.xml");

                    if (File.Exists(path))
                    {
                        options.IncludeXmlComments(path);
                    }
                }
            });


        }

        public override void Configure(IApplicationBuilder app, IRouteBuilder routes, IServiceProvider serviceProvider)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/" + _ss.RequestUrlPrefix + "/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
