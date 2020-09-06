using System;
using System.Collections.Generic;

namespace WandioMobilePhones.Core.Abstractions
{
    public interface IAggregateRoot<TID> where TID : IComparable 
    {
        public TID Id { get; set; }
    }
}
