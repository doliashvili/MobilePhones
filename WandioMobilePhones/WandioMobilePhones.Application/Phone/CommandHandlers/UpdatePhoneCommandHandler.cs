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
    public class UpdatePhoneCommandHandler : IRequestHandler<UpdatePhone>
    {
        private readonly IAggregateRepository<PhoneMobileAggregate, Guid> _repo;

        public UpdatePhoneCommandHandler(IAggregateRepository<PhoneMobileAggregate, Guid> repo)
        {
            _repo = repo;
        }
        public async Task<Unit> Handle(UpdatePhone request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Fetch().Include(x => x.Images).FirstOrDefaultAsync(x => x.Id == request.Id);
            if (obj == null)
                throw new Exception();

            obj.Update(request);
            await _repo.UpdateAsync(obj);

            return Unit.Value;
        }
    }
}
