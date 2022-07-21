using System.Data.Entity.ModelConfiguration;
using SFramework.Northwind.Entities.Concrete;

namespace SFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class RoleMap: EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            ToTable(@"Role", @"dbo");
            HasKey(x => x.Id);
            Property(x => x.Name).HasColumnName("Name");
        }
    }
}
