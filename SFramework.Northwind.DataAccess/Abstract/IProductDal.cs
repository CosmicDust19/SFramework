using System.Collections.Generic;
using SFramework.Core.DataAccess;
using SFramework.Northwind.Entities.ComplexTypes;
using SFramework.Northwind.Entities.Concrete;

namespace SFramework.Northwind.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {

        List<ProductDetails> GetProductDetails();

    }
}
