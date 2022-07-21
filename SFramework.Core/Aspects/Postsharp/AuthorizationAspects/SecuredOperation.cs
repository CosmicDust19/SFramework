using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading;
using PostSharp.Aspects;

namespace SFramework.Core.Aspects.Postsharp.AuthorizationAspects
{
    [Serializable]
    public class SecuredOperation : OnMethodBoundaryAspect
    {
        public string Roles { get; set; }

        public override void OnEntry(MethodExecutionArgs args)
        {
            List<string> roles = Roles.Split(',').Select(r => r.Trim()).ToList();
            bool isAuthorized = roles.Where(role => Thread.CurrentPrincipal.IsInRole(role)).Take(1).Count() == 1;
            if (isAuthorized == false)
            {
                throw new SecurityException("Unauthorized");
            }
            
        }

    }
}
