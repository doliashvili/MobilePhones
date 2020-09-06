using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WandioMobilePhones.Core.Abstractions;
using WandioMobilePhones.Domain.Commands;
using WandioMobilePhones.Domain.DomainObjects;

namespace WandioMobilePhones.Application.Phone.CommandHandlers
{
    public class RemoveImageCommandHandler : IRequestHandler<RemoveImage>
    {

        private readonly IAggregateRepository<PhoneMobileAggregate, Guid> _repo;

        public RemoveImageCommandHandler(IAggregateRepository<PhoneMobileAggregate, Guid> repo)
        {
            _repo = repo;
        }
        public async Task<Unit> Handle(RemoveImage request, CancellationToken cancellationToken)
        {

            var aggregate = await _repo.GetDbContext()
                .Set<PhoneMobileAggregate>()
                .Include(x => x.Images)
                .FirstOrDefaultAsync(x => x.Id == request.AggregateId);

            if (aggregate == null)
                throw new Exception($"Aggregate with id: {request.AggregateId} not found");

            aggregate.RemoveImage(request);
            await _repo.UpdateAsync(aggregate);

            return Unit.Value;
        }
    }
}
