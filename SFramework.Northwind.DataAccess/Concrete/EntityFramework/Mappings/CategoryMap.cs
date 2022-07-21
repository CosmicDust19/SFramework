using SFramework.Northwind.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace SFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable(@"Categories", @"dbo");
            HasKey(x => x.CategoryId);

            Property(x => x.CategoryId).HasColumnName("CategoryID");
            Property(x => x.CategoryName).HasColumnName("CategoryName");
        }
    }
}