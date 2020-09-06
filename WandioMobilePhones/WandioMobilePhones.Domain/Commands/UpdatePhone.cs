using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WandioMobilePhones.Core.Abstractions;

namespace WandioMobilePhones.Domain.Commands
{
    public class UpdatePhone : ICommand
    {
        public Guid Id { get; set; }

        [StringLength(60)]
        [Required]
        public string Name { get; set; }
        [StringLength(60)]
        [Required]
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
