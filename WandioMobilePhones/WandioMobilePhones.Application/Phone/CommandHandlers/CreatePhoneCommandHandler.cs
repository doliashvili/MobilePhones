using MediatR;
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
    public class CreatePhoneCommandHandler : IRequestHandler<CreatePhone>
    {
        private readonly IAggregateRepository<PhoneMobileAggregate, Guid> _repo;

        public CreatePhoneCommandHandler(IAggregateRepository<PhoneMobileAggregate, Guid> repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(CreatePhone request, CancellationToken cancellationToken)
        {
            await _repo.AddAsync(new PhoneMobileAggregate(request));
            return Unit.Value;
        }
    }
}
