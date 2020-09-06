using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using WandioMobilePhones.Application.Phone.Dtos;
using WandioMobilePhones.Application.Phone.Queries;
using WandioMobilePhones.Core.Abstractions;
using WandioMobilePhones.Domain.DomainObjects;

namespace WandioMobilePhones.Application.Phone.QueryHandlers
{
    public class GetPhoneByIdQueryHandler : IRequestHandler<GetPhoneByIdQuery, PhoneMobileDto>
    {
        private readonly IAggregateRepository<PhoneMobileAggregate, Guid> _repo;
        private readonly IMapper _mapper;

        public GetPhoneByIdQueryHandler(IAggregateRepository<PhoneMobileAggregate, Guid> repo,
            IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<PhoneMobileDto> Handle(GetPhoneByIdQuery request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Fetch().Include(x=>x.Images).FirstOrDefaultAsync(x=> x.Id == request.Id);

            if (obj == null)
                throw new Exception();

            return _mapper.Map<PhoneMobileDto>(obj);
        }
    }
}
