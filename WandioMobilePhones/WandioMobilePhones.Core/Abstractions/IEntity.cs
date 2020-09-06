using System;
using System.Collections.Generic;
using System.Text;

namespace WandioMobilePhones.Core.Abstractions
{
    public abstract class Entity<TID> where TID: IComparable
    {
        public abstract TID Id { get; set; }
        
    }
}
