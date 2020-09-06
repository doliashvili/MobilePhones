using System;
using System.Collections.Generic;
using System.Text;
using WandioMobilePhones.Core.Abstractions;

namespace WandioMobilePhones.Domain.Commands
{
    public class RemoveImage : ICommand
    {
        public Guid AggregateId { get; set; }
        public Guid PhotoId { get; set; }
    }
}
