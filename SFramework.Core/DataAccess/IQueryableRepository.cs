using System.Linq;
using SFramework.Core.Entities;

namespace SFramework.Core.DataAccess
{
    public interface IQueryableRepository<out T> where T : class, IEntity, new()
    {
        IQueryable<T> Table { get; }
    }
}
