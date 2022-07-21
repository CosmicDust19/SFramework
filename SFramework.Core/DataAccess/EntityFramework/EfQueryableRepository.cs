using System.Data.Entity;
using System.Linq;
using SFramework.Core.Entities;

namespace SFramework.Core.DataAccess.EntityFramework
{
    public class EfQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private readonly DbContext _context;

        private IDbSet<T> _entities;

        public EfQueryableRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Table => Entities;

        protected virtual IDbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());
    }
}
