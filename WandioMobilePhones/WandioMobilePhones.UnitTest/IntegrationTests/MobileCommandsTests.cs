using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using WandioMobilePhones.Application.Phone.CommandHandlers;
using WandioMobilePhones.Core.Abstractions;
using WandioMobilePhones.Domain.Commands;
using WandioMobilePhones.Domain.DomainObjects;
using Xunit;

namespace WandioMobilePhones.UnitTest.IntegrationTests
{
    public class MobileCommandsTests
    {
        private readonly IAggregateRepository<PhoneMobileAggregate, Guid> _aggregateRepo;
        private readonly IMediator _mediator;

        public MobileCommandsTests()
        {
            var provider = DiContainer.GetServiceProvider();

            _aggregateRepo = provider.GetRequiredService<IAggregateRepository<PhoneMobileAggregate, Guid>>();
            _mediator = provider.GetRequiredService<IMediator>();
        }


        [Fact]
        public async Task CreatePhoneAggregate()
        {
            var command = new CreatePhone() { Name = "sds", Manufacturer="jimi" };

            var beforeInsertCount = await _aggregateRepo.GetDbContext().Set<PhoneMobileAggregate>().CountAsync();

            await _mediator.Send(command);

            var afterInsertCount = await _aggregateRepo.GetDbContext().Set<PhoneMobileAggregate>().CountAsync();

            Assert.True(beforeInsertCount < afterInsertCount);
        }

        [Fact]
        public async Task DeletePhoneAggregate()
        {
            await AddTestData();

            var aggregate = await _aggregateRepo.Fetch().FirstOrDefaultAsync();
            var command = new DeletePhone(aggregate.Id);
            await _mediator.Send(command);
            var result = await _aggregateRepo.GetByIdAsync(aggregate.Id);
            Assert.Null(result);
        }

        private async Task AddTestData()
        {
           await _aggregateRepo.AddAsync(new PhoneMobileAggregate(new CreatePhone() { Name = "iphone", Manufacturer = "apple" }));
        }
    }
}
