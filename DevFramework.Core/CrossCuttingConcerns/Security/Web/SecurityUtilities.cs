using System;
using System.Web.Security;

namespace DevFramework.Core.CrossCuttingConcerns.Security.Web
{
    public class SecurityUtilities
    {
        public Identity FormsAutTicketToIdentity(FormsAuthenticationTicket ticket)
        {
            var identity = new Identity();

            identity.Id = SetId(ticket);
            identity.Name = SetName(ticket);
            identity.Email = SetEmail(ticket);
            identity.Roles = SetRoles(ticket);
            identity.FirstName = SetFirstName(ticket);
            identity.LastName = SetLastName(ticket);
            identity.AuthenticationType = SetAuthType();
            identity.IsAuthenticated = SetIsAuthenticated();
            
            return identity;
        }

        private bool SetIsAuthenticated()
        {
            return true;
        }

        private string SetAuthType()
        {
            return "Forms";
        }

        private string SetLastName(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[3];
        }

        private string SetFirstName(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[2];
        }

        private string[] SetRoles(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            string[] roles = data[1].Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
            return roles;
        }

        private string SetEmail(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[0];
        }

        private string SetName(FormsAuthenticationTicket ticket)
        {
            return ticket.Name;
        }

        private Guid SetId(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return Guid.Parse(data[4]);
        }
    }
}