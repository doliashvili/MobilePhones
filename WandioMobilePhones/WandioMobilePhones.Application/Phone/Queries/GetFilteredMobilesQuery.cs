using System;
using System.Collections.Generic;
using System.Text;
using WandioMobilePhones.Application.Phone.Dtos;
using WandioMobilePhones.Core.Abstractions;

namespace WandioMobilePhones.Application.Phone.Queries
{
    public class GetFilteredMobilesQuery : IQuery<List<PhoneMobileDto>>
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public decimal PriceFrom { get; set; } = decimal.MinValue;
        public decimal PriceTo { get; set; } = decimal.MaxValue;
    }
}
