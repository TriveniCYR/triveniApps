using AACalc.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace AACalc.Web.AuthenticationExt
{
    /// <summary>
    /// Security implementation
    /// Added by YReddy on 12/10/2015
    /// </summary>
    public class AACalcAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public string Permissions { get; set; }

        protected virtual IPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as IPrincipal; }
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string action = filterContext.ActionDescriptor.ActionName;
            Authentication auth = null;            
            if (CurrentUser != null)
            {
                HttpCookie authCookie =
                  filterContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null && !string.IsNullOrWhiteSpace(authCookie.Value))
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    AuthenticationSerialize serialiseAuth = serializer.Deserialize<AuthenticationSerialize>(authTicket.UserData);
                    auth = new Authentication(authTicket.Name);
                    if (authCookie != null && !string.IsNullOrWhiteSpace(authCookie.Value))
                        auth.UserContext = serialiseAuth.UserContext;

                    if (auth.UserContext.RoleId == 1)
                    {
                        HttpContext.Current.User = auth;
                    }
                    else
                    {
                        filterContext.Result = new RedirectResult("/Account/UnAuthorized");
                    }
                }
            }
        }
    }
}