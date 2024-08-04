using System.Reflection;

using CardGame.Application.Business;
using CardGame.Application.Contracts;
using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace CardGame.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IDeckService, DeckService>();
            services.AddScoped<IPlayCardGameService, CardClashGameService>();
            return services;
        }
    }
}
