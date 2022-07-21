using SFramework.Core.DataAccess;
using SFramework.Northwind.Entities.Concrete;

namespace SFramework.Northwind.DataAccess.Abstract
{
    public interface ICategoryDal:IEntityRepository<Category>
    {
    }
}
