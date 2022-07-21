using SFramework.Northwind.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace SFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ProductMap: EntityTypeConfiguration<Product>
    {

        public ProductMap()
        {

            ToTable(@"Products", @"dbo");
            HasKey(x => x.ProductId);
            
            Property(x => x.ProductId).HasColumnName("ProductID");
            Property(x => x.CategoryId).HasColumnName("CategoryID");
            Property(x => x.ProductName).HasColumnName("ProductName");
            Property(x => x.QuantityPerUnit).HasColumnName("QuantityPerUnit");
            Property(x => x.UnitPrice).HasColumnName("UnitPrice");

        }

    }
}
