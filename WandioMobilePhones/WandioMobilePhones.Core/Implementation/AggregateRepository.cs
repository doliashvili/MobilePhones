using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WandioMobilePhones.Core.Abstractions;
using WandioMobilePhones.Core.Base;

namespace WandioMobilePhones.Core.Implementation
{
    public class AggregateRepository<TContext, TAggregate, TID>
        : IAggregateRepository<TAggregate, TID>
        where TAggregate : AggregateRoot<TID>
        where TID : IComparable where TContext : DbContext
    {
        private readonly TContext _db;

        public AggregateRepository(TContext db) => _db = db;

        public async Task AddAsync(TAggregate aggregate)
        {
            _db.Set<TAggregate>().Add(aggregate);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(TID id)
        {
            var entity = _db.Set<TAggregate>().Find(id);
            if (entity == null)
                return false;
            
            _db.Set<TAggregate>().Remove(entity);
            return await _db.SaveChangesAsync() > 0;
        }

        public IQueryable<TAggregate> Fetch()
            => _db.Set<TAggregate>().AsNoTracking();

        public async Task<IEnumerable<TAggregate>> GetAllAsync(Expression<Func<TAggregate, bool>> filter = null)
        {
            if (filter != null)
                return await _db.Set<TAggregate>().AsNoTracking().Where(filter).ToListAsync();
            else
                return await _db.Set<TAggregate>().AsNoTracking().ToListAsync();
        }

        public Task<TAggregate> GetByIdAsync(TID id)
            => _db.Set<TAggregate>().AsNoTracking().FirstOrDefaultAsync(x => x.Id.CompareTo(id) == 0);


        public DbContext GetDbContext() => _db;

        public async Task UpdateAsync(TAggregate aggregate)
        {
            _db.Set<TAggregate>().Update(aggregate).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

    }
}
