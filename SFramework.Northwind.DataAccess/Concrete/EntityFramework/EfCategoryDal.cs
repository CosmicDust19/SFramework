using SFramework.Core.DataAccess.EntityFramework;
using SFramework.Northwind.DataAccess.Abstract;
using SFramework.Northwind.Entities.Concrete;

namespace SFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal:EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
    }
}
