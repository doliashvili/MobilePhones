using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using WandioMobilePhones.Application.Phone.Dtos;
using WandioMobilePhones.Application.Phone.Queries;
using WandioMobilePhones.Core.Abstractions;
using WandioMobilePhones.Core.Extensions;
using WandioMobilePhones.Domain.DomainObjects;

namespace WandioMobilePhones.Application.Phone.QueryHandlers
{ 
    public class GetFilteredMobilesQueryHandler
        : IRequestHandler<GetFilteredMobilesQuery, List<PhoneMobileDto>>
    {

        private readonly IAggregateRepository<PhoneMobileAggregate, Guid> _repo;
        private readonly IMapper _mapper;

        public GetFilteredMobilesQueryHandler(IAggregateRepository<PhoneMobileAggregate, Guid> repo,
            IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<PhoneMobileDto>> Handle(GetFilteredMobilesQuery request, CancellationToken cancellationToken)
        {

            Expression<Func<PhoneMobileAggregate, bool>> predicate =
                x => x.Price >= request.PriceFrom && x.Price <= request.PriceTo;

            if (!string.IsNullOrWhiteSpace(request.Manufacturer))
            {
                Expression<Func<PhoneMobileAggregate, bool>> manufacturerExpression =
                    x => x.Manufacturer.Contains(request.Manufacturer, StringComparison.OrdinalIgnoreCase);
                predicate = predicate.And(manufacturerExpression);
            }

            if (!string.IsNullOrWhiteSpace(request.Model))
            {
                Expression<Func<PhoneMobileAggregate, bool>> modelExpression =
                    x => x.Name.Contains(request.Model, StringComparison.OrdinalIgnoreCase);
                predicate = predicate.And(modelExpression);
            }

            var data = await _repo.Fetch()
                .Include(x=>x.Images)
                .Where(predicate).ToListAsync();

            if (data == null)
                return default;

            return _mapper.Map<List<PhoneMobileDto>>(data);
        }
    }
}
