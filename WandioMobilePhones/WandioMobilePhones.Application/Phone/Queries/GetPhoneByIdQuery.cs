using System;
using System.Collections.Generic;
using System.Text;
using WandioMobilePhones.Application.Phone.Dtos;
using WandioMobilePhones.Core.Abstractions;

namespace WandioMobilePhones.Application.Phone.Queries
{
    public class GetPhoneByIdQuery : IQuery<PhoneMobileDto>
    {
        public Guid Id { get; set; }
        public GetPhoneByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
