using System;
using System.Collections.Generic;
using System.Text;
using WandioMobilePhones.Core.Abstractions;

namespace WandioMobilePhones.Domain.Commands
{
    public class UpdatePhoneName : ICommand
    {
        public Guid AggregateId { get; set; }
        public string NewName { get; set; }
    }
}
