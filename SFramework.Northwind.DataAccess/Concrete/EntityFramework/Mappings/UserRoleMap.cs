using System.Data.Entity.ModelConfiguration;
using SFramework.Northwind.Entities.Concrete;

namespace SFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserRoleMap:EntityTypeConfiguration<UserRole>
    {

        public UserRoleMap()
        {
            ToTable(@"UserRoles", @"dbo");
            HasKey(x => x.Id);
            Property(x => x.RoleId).HasColumnName("RoleId");
            Property(x => x.UserId).HasColumnName("UserId");
        }
    }
}
