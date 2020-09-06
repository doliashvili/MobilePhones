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
    public class AddPhotoCommandHandler : IRequestHandler<AddPhoto>
    {
        private readonly IAggregateRepository<PhoneMobileAggregate, Guid> _repo;

        public AddPhotoCommandHandler(IAggregateRepository<PhoneMobileAggregate, Guid> repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(AddPhoto request, CancellationToken cancellationToken)
        {
            var aggregate = await _repo.GetDbContext()
                .Set<PhoneMobileAggregate>()
                .Include(x => x.Images)
                .FirstOrDefaultAsync();

            if (aggregate == null)
                throw new Exception();

            aggregate.AddPhoto(request);
            await _repo.UpdateAsync(aggregate);

            return Unit.Value;
        }
    }
}
