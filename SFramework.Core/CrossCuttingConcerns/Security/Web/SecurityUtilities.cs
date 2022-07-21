using System;
using System.Web.Security;

namespace SFramework.Core.CrossCuttingConcerns.Security.Web
{
    public class SecurityUtilities
    {
        public Identity FormAuthTicketToIdentity(FormsAuthenticationTicket ticket)
        {
            string[] userData = ticket.UserData.Split('|');
            return new Identity
            {
                Id = SetId(userData),
                Name = SetName(ticket),
                Email = SetEmail(userData),
                Roles = SetRoles(userData),
                FirstName = SetFirstName(userData),
                LastName = SetLastName(userData),
                AuthenticationType = SetAuthType(),
                IsAuthenticated = SetIsAuthenticated()
            };
        }

        private Guid SetId(string[] userData)
        {
            return new Guid(userData[4]);
        }

        private string SetName(FormsAuthenticationTicket ticket)
        {
            return ticket.Name;
        }

        private string SetEmail(string[] userData)
        {
            return userData[0];
        }

        private string[] SetRoles(string[] userData)
        {
            return userData[1].Split(',');
        }

        private string SetFirstName(string[] userData)
        {
            return userData[2];
        }

        private string SetLastName(string[] userData)
        {
            return userData[3];
        }

        private string SetAuthType()
        {
            return "Forms";
        }

        private bool SetIsAuthenticated()
        {
            return true;
        }
    }
}
