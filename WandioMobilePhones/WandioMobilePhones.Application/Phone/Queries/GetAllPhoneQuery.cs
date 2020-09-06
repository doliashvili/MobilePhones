using System.Collections.Generic;
using WandioMobilePhones.Application.Phone.Dtos;
using WandioMobilePhones.Core.Abstractions;

namespace WandioMobilePhones.Application.Phone.Queries
{
    public class GetAllPhoneQuery : IQuery<List<PhoneMobileDto>>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        
    }
}
