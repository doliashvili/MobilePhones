using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WandioMobilePhones.Core.Abstractions;
using WandioMobilePhones.Domain.Commands;
using WandioMobilePhones.Domain.DomainObjects;

namespace WandioMobilePhones.Application.Phone.CommandHandlers
{
    public class DeletePhoneHandler : IRequestHandler<DeletePhone>
    {
        private readonly IAggregateRepository<PhoneMobileAggregate, Guid> _repo;

        public DeletePhoneHandler(IAggregateRepository<PhoneMobileAggregate, Guid> repo)
        {
            _repo = repo;
        }
        public async Task<Unit> Handle(DeletePhone request, CancellationToken cancellationToken)
        {
            var isDeleted = await _repo.DeleteAsync(request.Id);
            if (!isDeleted)
                throw new Exception();
            return Unit.Value;
        }
    }
}
