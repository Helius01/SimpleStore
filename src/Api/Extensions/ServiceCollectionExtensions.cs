using AutoMapper;
using SimpleShop.src.Api.MapProfiles;

namespace SimpleShop.src.Api.Extensions;

/// <summary>
/// Provides extension functions on IServiceCollection object
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add auto mapper with its profiles
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        return services.AddSingleton(provider => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new ProductMapProfile());
        }).CreateMapper());
    }
}