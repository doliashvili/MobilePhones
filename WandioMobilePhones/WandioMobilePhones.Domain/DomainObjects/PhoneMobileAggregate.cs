using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WandioMobilePhones.Core.Base;
using WandioMobilePhones.Domain.AggregateExceptions;
using WandioMobilePhones.Domain.Commands;

namespace WandioMobilePhones.Domain.DomainObjects
{
    public class PhoneMobileAggregate : AggregateRoot<Guid>
    {
        [Key]
        public override Guid Id { get; set; }

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

        [StringLength(60)]
        public string Memory { get; set; }

        [StringLength(40)]
        public string OS { get; set; }
        public decimal Price { get; set; }
        public virtual List<Image> Images { get; set; }
        public string Video { get; set; }
        
        

        public PhoneMobileAggregate()
        {
        }

        public PhoneMobileAggregate(CreatePhone command)
        {
            Id = Guid.NewGuid();
            Name = command.Name;
            Manufacturer = command.Manufacturer;
            Size = command.Size;
            Weight = command.Weight;
            ScreenSizeAndResolution = command.ScreenSizeAndResolution;
            Procesor = command.Procesor;
            Memory = command.Memory;
            OS = command.OS;
            Price = command.Price;
            Video = command.Video;
            Images = command.ImageUrls?.Select(x => new Image(x))?.ToList();
        }

        public PhoneMobileAggregate(Guid id, string name, string manufacturer, string size, double weight, string screenSizeAndResolution, string procesor, string memory, string oS, decimal price, List<Image> images, string video)
        {
            Id = id;
            Name = name;
            Manufacturer = manufacturer;
            Size = size;
            Weight = weight;
            ScreenSizeAndResolution = screenSizeAndResolution;
            Procesor = procesor;
            Memory = memory;
            OS = oS;
            Price = price;
            Images = images;
            Video = video;
        }

        public void RemoveImage(RemoveImage command)
        {
            if (Images == null)
                throw new ImageIsNullException("Phone not contains images");

            Images.RemoveAll(x => x.Id == command.PhotoId);
        }

        public void AddPhoto(AddPhoto command)
        {
            Images ??= new List<Image>();
            Images.Add(command.Image);
        }

        public void UpdateName(UpdatePhoneName command)
        {
            if (string.IsNullOrWhiteSpace(command.NewName))
                throw new Exception(); //TODO

            Name = command.NewName;
        }

        public void Update(UpdatePhone command)
        {
            Name = command.Name;
            Manufacturer = command.Manufacturer;
            Size = command.Size;
            Weight = command.Weight;
            ScreenSizeAndResolution = command.ScreenSizeAndResolution;
            Procesor = command.Procesor;
            Memory = command.Memory;
            OS = command.OS;
            Price = command.Price;
            Video = command.Video;
            for (int i = 0; i < command.ImageUrls.Count; i++)
            {
                if (Images.Count - 1 >= i)
                {
                    Images[i].PhotoUrl = command.ImageUrls[i];
                }
                else
                {
                    Images.Add(new Image(command.ImageUrls[i]));
                }
            }
        }

    }
}
