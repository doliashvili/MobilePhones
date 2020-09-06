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
    public class UpdatePhoneNameCommandHandler : IRequestHandler<UpdatePhoneName>
    {
        private readonly IAggregateRepository<PhoneMobileAggregate, Guid> _repo;

        public UpdatePhoneNameCommandHandler(IAggregateRepository<PhoneMobileAggregate, Guid> repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(UpdatePhoneName request, CancellationToken cancellationToken)
        {
            var aggregate = await _repo.GetDbContext()
                 .Set<PhoneMobileAggregate>()
                 .FirstOrDefaultAsync(x => x.Id == request.AggregateId);

            if (aggregate==null)
            {
                throw new Exception();
            }

            aggregate.UpdateName(request);
            await _repo.UpdateAsync(aggregate);

            return Unit.Value;
        }
    }
}
