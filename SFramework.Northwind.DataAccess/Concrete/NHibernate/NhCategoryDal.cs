using SFramework.Core.DataAccess.NHibernate;
using SFramework.Northwind.DataAccess.Abstract;
using SFramework.Northwind.Entities.Concrete;

namespace SFramework.Northwind.DataAccess.Concrete.NHibernate
{
    public class NhCategoryDal: NhEntityRepositoryBase<Category>, ICategoryDal
    {
        public NhCategoryDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }
    }
}
