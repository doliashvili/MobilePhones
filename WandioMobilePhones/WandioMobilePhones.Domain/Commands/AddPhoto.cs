using System;
using System.Collections.Generic;
using System.Text;
using WandioMobilePhones.Core.Abstractions;
using WandioMobilePhones.Domain.DomainObjects;

namespace WandioMobilePhones.Domain.Commands
{
    public class AddPhoto : ICommand
    {
        public Guid Aggregate { get; set; }
        public Image Image { get; set; }
    }
}
