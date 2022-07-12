using System;
using InventoryManagement.Application.Contracts;
using InventoryManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InventoryManagementDbContext>(options =>
            {
                options.UseInMemoryDatabase("IMS");
                options.EnableSensitiveDataLogging();
            });

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IInventoryRepository, InventoryRepository>();

            return services;
        }
    }
}

