using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WandioMobilePhones.Core.Abstractions;

namespace WandioMobilePhones.Domain.DomainObjects
{
    public class Image : Entity<Guid>
    {
        public Image(string imageUrl)
        {
            Id = Guid.NewGuid();
            PhotoUrl = imageUrl;
        }

        public Image()
        {
        }

        [Key]
        public override Guid Id { get; set; }
        [StringLength(100)]
        public string PhotoUrl { get; set; }
    }
}
