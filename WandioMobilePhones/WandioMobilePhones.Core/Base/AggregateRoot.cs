using System;
using System.Collections.Generic;
using System.Text;
using WandioMobilePhones.Core.Abstractions;

namespace WandioMobilePhones.Core.Base
{
    public abstract class AggregateRoot<TID> :
        IAggregateRoot<TID> where TID : IComparable
    {
        public abstract TID Id { get; set; }
    }
}
