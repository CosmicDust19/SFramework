using System.Collections.Generic;
using System.Linq;
using SFramework.Core.DataAccess.EntityFramework;
using SFramework.Northwind.DataAccess.Abstract;
using SFramework.Northwind.Entities.ComplexTypes;
using SFramework.Northwind.Entities.Concrete;

namespace SFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetails> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return (from p in context.Products
                        join c in context.Categories on p.CategoryId equals c.CategoryId
                        select new ProductDetails()
                        {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            CategoryName = c.CategoryName
                        }).ToList();
            }
        }
    }
}
