using ChurrasTrinca.API.Extensions;
using ChurrasTrinca.Business.Interfaces;
using ChurrasTrinca.Business.Notificacoes;
using ChurrasTrinca.Business.Services;
using ChurrasTrinca.Data.Context;
using ChurrasTrinca.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ChurrasTrinca.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IParticipanteRepository, ParticipanteRepository>();
            services.AddScoped<IChurrasRepository, ChurrasRepository>();
            
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IChurrasService, ChurrasService>();
            services.AddScoped<IParticipanteService, ParticipanteService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}