using System;
using System.ServiceModel.Security;
using PostSharp.Aspects;

namespace DevFramework.Core.Aspects.PostSharp.AuthorizationAspects
{
    [Serializable]
    public class SecuredOperation: OnMethodBoundaryAspect
    {
        public string Roles { get; set; }

        public override void OnEntry(MethodExecutionArgs args)
        {
            string[] roles = Roles.Split(',');
            bool isAuthorized = false;

            foreach (var role in roles)
            {
                if (System.Threading.Thread.CurrentPrincipal.IsInRole(role.TrimStart().TrimEnd()))
                {
                    isAuthorized = true;
                }
            }

            if (!isAuthorized)
            {
                throw new SecurityAccessDeniedException("You are not authorized");
            }
        }
    }
}