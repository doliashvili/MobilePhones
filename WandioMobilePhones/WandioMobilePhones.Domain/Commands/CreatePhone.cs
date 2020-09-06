using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WandioMobilePhones.Core.Abstractions;
using WandioMobilePhones.Domain.DomainObjects;

namespace WandioMobilePhones.Domain.Commands
{
    public class CreatePhone : ICommand
    {
        [StringLength(60)]
        public string Name { get; set; }
        [StringLength(60)]
        public string Manufacturer { get; set; }
        [StringLength(60)]
        public string Size { get; set; }
        public double Weight { get; set; }
        [StringLength(60)]
        public string ScreenSizeAndResolution { get; set; }
        [StringLength(60)]
        public string Procesor { get; set; }
        public string Memory { get; set; }
        [StringLength(40)]
        public string OS { get; set; }
        public decimal Price { get; set; }
        public List<string> ImageUrls { get; set; }
        public string Video { get; set; }
    }
}
