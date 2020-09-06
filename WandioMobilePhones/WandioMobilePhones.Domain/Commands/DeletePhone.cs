using System;
using System.Collections.Generic;
using System.Text;
using WandioMobilePhones.Core.Abstractions;

namespace WandioMobilePhones.Domain.Commands
{
    public class DeletePhone : ICommand
    {
        public DeletePhone(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
