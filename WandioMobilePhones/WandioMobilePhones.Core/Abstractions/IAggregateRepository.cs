using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WandioMobilePhones.Core.Abstractions
{
    public interface IAggregateRepository<TAggregate, TID> 
        where TAggregate: IAggregateRoot<TID> where TID : IComparable 
    {
        Task AddAsync(TAggregate aggregate);
        Task<IEnumerable<TAggregate>> GetAllAsync(Expression<Func<TAggregate, bool>> filter = null);
        IQueryable<TAggregate> Fetch();
        Task<TAggregate> GetByIdAsync(TID id);
        Task UpdateAsync(TAggregate aggregate);
        Task<bool> DeleteAsync(TID id);
        DbContext GetDbContext();
    }
}
