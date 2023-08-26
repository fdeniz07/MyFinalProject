using Microsoft.Extensions.DependencyInjection;
using System;

namespace Core.Utilities.IoC
{
    //Bu class’in amaci IoC (Inversion Of Control) yapimizi yönetmeyi saglayacaktir.
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
