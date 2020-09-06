using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WandioMobilePhones.Application.AutoMapper;
using WandioMobilePhones.Application.Phone.CommandHandlers;
using WandioMobilePhones.Core.Abstractions;
using WandioMobilePhones.Core.Implementation;
using WandioMobilePhones.Domain.DomainObjects;
using WandioMobilePhones.Infrastructure;

namespace WandioMobilePhones.UnitTest
{
    public static class DiContainer
    {
        private static IServiceCollection _services;

        public static IServiceProvider GetServiceProvider()
        {
            if(_services == null)
            {
                _services = new ServiceCollection();
                AddServices();
            }
            return _services.BuildServiceProvider();
        }
           

        private static void AddServices()
        {
            _services.AddDbContext<PhoneDbContext>(options =>
                    options.UseInMemoryDatabase("PhoneDbContext"));

            _services.AddScoped<IAggregateRepository<PhoneMobileAggregate, Guid>, AggregateRepository<PhoneDbContext, PhoneMobileAggregate, Guid>>();
            _services.AddMediatR(typeof(CreatePhoneCommandHandler).Assembly);
            _services.AddAutoMapper(typeof(AutoMaper).Assembly);

        }

    }
}
