using System.Collections.Generic;
using SFramework.Northwind.Business.Abstract;
using SFramework.Northwind.DataAccess.Abstract;
using SFramework.Northwind.Entities.ComplexTypes;
using SFramework.Northwind.Entities.Concrete;

namespace SFramework.Northwind.Business.Concrete.Managers
{
    public class UserManager:IUserService
    {

        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetByUserNameAndPassword(string userName, string password)
        {
            return _userDal.Get(u => u.UserName == userName && u.Password == password);
        }

        public List<UserRoleItem> GetUserRoles(User user)
        {
            return _userDal.GetUserRoles(user);
        }
    }
}
