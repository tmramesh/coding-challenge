using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace LoanManagementService.Filters
{
    public class RequireHttpsAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.RequestUri.Scheme == Uri.UriSchemeHttps)
            {
                base.OnAuthorization(actionContext);
            }
            else
            {
                // Construct Error response for HTTP requests.
                // Now I'm allowing both HTTP and HTTPS to access the resource
                base.OnAuthorization(actionContext);
            }
        }

    }
}