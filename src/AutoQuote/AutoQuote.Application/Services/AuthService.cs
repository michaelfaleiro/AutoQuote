
using AutoQuote.Application.UseCase.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace AutoQuote.Application.Services;

public static class AuthService
{
    public static IServiceCollection AddAuthService(this IServiceCollection services)
    {
        services.AddScoped<LoginUseCase>();
        services.AddScoped<RefreshTokenUseCase>();
        return services;
    }
    
}