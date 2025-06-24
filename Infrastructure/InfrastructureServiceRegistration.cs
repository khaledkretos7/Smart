using Application.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IAdvertisementService, AdvertisementService>();
            services.AddScoped<IPublicServiceService, PublicServiceService>();

            services.AddScoped<JwtService>();

            return services;
        }
    }
}
