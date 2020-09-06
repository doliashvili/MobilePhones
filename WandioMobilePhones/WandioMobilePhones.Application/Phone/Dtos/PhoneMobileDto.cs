using System;
using System.Collections.Generic;
using WandioMobilePhones.Domain.DomainObjects;

namespace WandioMobilePhones.Application.Phone.Dtos
{
    public class PhoneMobileDto
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Size { get; set; }
        public double Weight { get; set; }
        public string ScreenSizeAndResolution { get; set; }
        public string Procesor { get; set; }
        public string Memory { get; set; }
        public string OS { get; set; }
        public decimal Price { get; set; }
        public virtual List<Image> Images { get; set; }
        public string Video { get; set; }

    }
}
