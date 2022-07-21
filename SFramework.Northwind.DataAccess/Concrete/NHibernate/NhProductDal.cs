using System.Collections.Generic;
using System.Linq;
using SFramework.Core.DataAccess.NHibernate;
using SFramework.Northwind.DataAccess.Abstract;
using SFramework.Northwind.Entities.ComplexTypes;
using SFramework.Northwind.Entities.Concrete;

namespace SFramework.Northwind.DataAccess.Concrete.NHibernate
{
    public class NhProductDal : NhEntityRepositoryBase<Product>, IProductDal
    {

        private NHibernateHelper _nHibernateHelper;
        public NhProductDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public List<ProductDetails> GetProductDetails()
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                return (from p in session.Query<Product>()
                    join c in session.Query<Category>() on p.CategoryId equals c.CategoryId
                    select new ProductDetails
                    {
                        ProductId = p.ProductId,
                        CategoryName = c.CategoryName,
                        ProductName = p.ProductName
                    }).ToList();
            }
        }
    }
}
