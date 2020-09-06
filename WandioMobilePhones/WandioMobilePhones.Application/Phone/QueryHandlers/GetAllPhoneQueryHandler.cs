using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WandioMobilePhones.Application.Phone.Dtos;
using WandioMobilePhones.Application.Phone.Queries;
using WandioMobilePhones.Core.Abstractions;
using WandioMobilePhones.Domain.DomainObjects;

namespace WandioMobilePhones.Application.Phone.QueryHandlers
{
    public class GetAllPhoneQueryHandler : IRequestHandler<GetAllPhoneQuery, List<PhoneMobileDto>>
    {
        private readonly IAggregateRepository<PhoneMobileAggregate, Guid> _repo;
        private readonly IMapper _mapper;

        public GetAllPhoneQueryHandler(IAggregateRepository<PhoneMobileAggregate, Guid> repo,
            IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<PhoneMobileDto>> Handle(GetAllPhoneQuery request, CancellationToken cancellationToken)
        {
            var result = await _repo.Fetch()
                .Include(x => x.Images)
                .Skip(request.Skip)
                .Take(request.Take)
                .ToListAsync();

            if (result == null)
                return default;

            return _mapper.Map<List<PhoneMobileDto>>(result);
        }
    }
}
