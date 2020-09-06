using AutoMapper;
using System.Collections.Generic;
using WandioMobilePhones.Application.Phone.Dtos;
using WandioMobilePhones.Domain.DomainObjects;

namespace WandioMobilePhones.Application.AutoMapper
{
    public class AutoMaper : Profile
    {
        public AutoMaper()
        {
            CreateMap<PhoneMobileAggregate, PhoneMobileDto>();
        }
    }
}
