using System;
using System.Text;
using System.Web;
using System.Web.Security;

namespace SFramework.Core.CrossCuttingConcerns.Security.Web
{
    public class AuthenticationHelper
    {
        public static void CreateAuthCookie(Guid id, string userName, string email, DateTime expirationDate, string[] roles, bool rememberMe, string firstName, string lastName)
        {
            var authTicket = new FormsAuthenticationTicket(1, userName, DateTime.Now, expirationDate, rememberMe, CreateAuthTags(email, roles, firstName, lastName, id));
            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
        }

        private static string CreateAuthTags(string email, string[] roles, string firstName, string lastName, Guid id)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(email);
            stringBuilder.Append("|");
            stringBuilder.Append(string.Join(",", roles));
            stringBuilder.Append("|");
            stringBuilder.Append(firstName);
            stringBuilder.AppendLine("|");
            stringBuilder.AppendLine(lastName);
            stringBuilder.AppendLine("|");
            stringBuilder.Append(id);
            return stringBuilder.ToString();
        }
    }
}
