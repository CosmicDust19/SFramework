using System.Collections.Generic;
using SFramework.Northwind.Entities.ComplexTypes;
using SFramework.Northwind.Entities.Concrete;

namespace SFramework.Northwind.Business.Abstract
{
    public interface IUserService
    {
        User GetByUserNameAndPassword(string userName, string password);

        List<UserRoleItem> GetUserRoles(User user);
    }
}
