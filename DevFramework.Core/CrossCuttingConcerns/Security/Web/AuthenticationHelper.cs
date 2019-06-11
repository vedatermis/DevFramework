using System;
using System.Text;
using System.Web;
using System.Web.Security;

namespace DevFramework.Core.CrossCuttingConcerns.Security.Web
{
    public class AuthenticationHelper
    {
        public static void CreateAuthCookie(Guid id, string userName, string eMail, DateTime expiration, string[] roles, bool rememberMe, string firstName, string lastName)
        {
            var authTicket = new FormsAuthenticationTicket(1, userName, DateTime.Now, expiration, rememberMe,
                CreateAuthTags(eMail, roles, firstName, lastName, id));

            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
        }

        private static string CreateAuthTags(string eMail, string[] roles, string firstName, string lastName, Guid id)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(eMail);
            stringBuilder.Append("|");

            for (var index = 0; index < roles.Length; index++)
            {
                stringBuilder.Append(roles[index]);

                if (index < roles.Length - 1)
                {
                    stringBuilder.Append(",");
                }
            }

            stringBuilder.Append("|");

            stringBuilder.Append(firstName);
            stringBuilder.Append("|");

            stringBuilder.Append(lastName);
            stringBuilder.Append("|");

            stringBuilder.Append(id);

            return stringBuilder.ToString();
        }
    }
}