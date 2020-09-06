using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WandioMobilePhones.Application;
using WandioMobilePhones.Application.AutoMapper;
using WandioMobilePhones.Application.Phone.CommandHandlers;
using WandioMobilePhones.Core.Abstractions;
using WandioMobilePhones.Core.Implementation;
using WandioMobilePhones.Domain.DomainObjects;

namespace WandioMobilePhones.Infrastructure
{
    public static class DIContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<PhoneDbContext>(options =>
                    options.UseInMemoryDatabase("PhoneDbContext"));
            }
            else
            {
                services.AddDbContext<PhoneDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(PhoneDbContext).Assembly.FullName)));
            }


            services.AddScoped<IAggregateRepository<PhoneMobileAggregate, Guid>, AggregateRepository<PhoneDbContext, PhoneMobileAggregate, Guid>>();
            services.AddMediatR(typeof(CreatePhoneCommandHandler).Assembly);
            services.AddAutoMapper(typeof(AutoMaper).Assembly);


            return services;
        }

    }
}
