using System.Data.Entity.ModelConfiguration;
using SFramework.Northwind.Entities.Concrete;

namespace SFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable(@"Users", @"dbo");
            HasKey(user => user.Id);

            Property(user => user.FirstName).HasColumnName("FirstName");
            Property(user => user.LastName).HasColumnName("LastName");
            Property(user => user.Email).HasColumnName("Email");
            Property(user => user.Password).HasColumnName("Password");
            Property(user => user.UserName).HasColumnName("UserName");

        }
    }
}
