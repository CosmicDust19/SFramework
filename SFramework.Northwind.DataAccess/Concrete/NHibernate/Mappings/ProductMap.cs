using FluentNHibernate.Mapping;
using SFramework.Northwind.Entities.Concrete;

namespace SFramework.Northwind.DataAccess.Concrete.NHibernate.Mappings
{
    public class ProductMap:ClassMap<Product> 
    {

        public ProductMap()
        {
            Table(@"Products");
            LazyLoad();

            Id(x => x.ProductId).Column("ProductID");
            Map(x => x.CategoryId).Column("CategoryID");
            Map(x => x.ProductName).Column("ProductName");
            Map(x => x.QuantityPerUnit).Column("QuantityPerUnit");
            Map(x => x.UnitPrice).Column("UnitPrice");
        }

    }
}
