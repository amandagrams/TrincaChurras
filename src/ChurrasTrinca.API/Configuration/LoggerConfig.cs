using System;
using Elmah.Io.AspNetCore;
using Elmah.Io.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevIO.Api.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "371302be9ea140218defaf09266434d9";
                o.LogId = new Guid("1d622230-f6a7-431e-b0d9-432888ed7bbd");
            });

            //services.AddLogging(builder =>
            //{
            //    builder.AddElmahIo(o =>
            //    {
            //        o.ApiKey = "371302be9ea140218defaf09266434d9";
            //        o.LogId = new Guid("1d622230-f6a7-431e-b0d9-432888ed7bbd");
            //    });
            //    builder.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
            //});

            /* services.AddHealthChecks()
                .AddElmahIoPublisher("371302be9ea140218defaf09266434d9", new Guid("1d622230-f6a7-431e-b0d9-432888ed7bbd"), "API Churras Trinca")
                .AddCheck("Produtos", new SqlServerHealthCheck("sql",configuration.GetConnectionString("DefaultConnection")))
                .AddSqlServer(configuration.GetConnectionString("DefaultConnection"), name: "BancoSQL");

            services.AddHealthChecksUI(); */

            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            /*app.UseHealthChecks("/api/hc", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.UseHealthChecksUI(options => { options.UIPath = "/api/hc-ui"; }); */

            return app;
        }
    }
}