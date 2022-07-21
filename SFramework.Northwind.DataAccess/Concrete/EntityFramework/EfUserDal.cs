using System.Collections.Generic;
using System.Linq;
using SFramework.Core.DataAccess.EntityFramework;
using SFramework.Northwind.DataAccess.Abstract;
using SFramework.Northwind.Entities.ComplexTypes;
using SFramework.Northwind.Entities.Concrete;

namespace SFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<UserRoleItem> GetUserRoles(User user)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return (from ur in context.UserRoles
                        join r in context.Roles
                            on ur.RoleId equals r.Id
                        where ur.UserId == user.Id
                        select new UserRoleItem { RoleName = r.Name })
                    .ToList();
            }
        }
    }
}
