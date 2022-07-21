using System;
using System.Linq;
using System.Web.Mvc;
using SFramework.Core.CrossCuttingConcerns.Security.Web;
using SFramework.Northwind.Business.Abstract;
using SFramework.Northwind.Entities.Concrete;

namespace SFramework.Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public string Login(string userName, string password)
        {
            User user = _userService.GetByUserNameAndPassword(userName, password);
            if (user == null) return "Wrong username or password!";
            AuthenticationHelper.CreateAuthCookie(
                new Guid(),
                user.UserName,
                user.Email,
                DateTime.Now.AddDays(5),
                _userService.GetUserRoles(user).Select(u => u.RoleName).ToArray(),
                false,
                user.FirstName,
                user.LastName
            );
            return "Authenticated";

        }
    }
}