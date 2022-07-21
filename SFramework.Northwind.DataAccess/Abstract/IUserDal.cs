using System.Collections.Generic;
using SFramework.Core.DataAccess;
using SFramework.Northwind.Entities.ComplexTypes;
using SFramework.Northwind.Entities.Concrete;

namespace SFramework.Northwind.DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<UserRoleItem> GetUserRoles(User user);
    }
}
