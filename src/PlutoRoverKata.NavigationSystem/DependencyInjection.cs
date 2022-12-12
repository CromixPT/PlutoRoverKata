using Microsoft.Extensions.DependencyInjection;
using PlutoRoverKata.NavigationSystem.Entities;
using PlutoRoverKata.NavigationSystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace PlutoRoverKata.NavigationSystem;
public static class DependencyInjection
{
    public static IServiceCollection AddNavigator(this IServiceCollection services,IConfiguration configuration)
    {
        
        services.Configure<RoverOptions>(o => configuration.GetRequiredSection(RoverOptions.ConfigurationKey));
        services.Configure<PlanetaryGridOptions>(o => configuration.GetRequiredSection(PlanetaryGridOptions.ConfigurationKey));

        services.AddSingleton<Navigator>();

        return services;

    }

}
