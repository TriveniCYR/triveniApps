using AACalc.BAL;
using AACalc.Common.Helper;
using AACalc.Entity.ViewModel;
using AACalc.Web.AuthenticationExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace AACalc.Web.Controllers
{
    public class AccountController : BaseController
    {
        public static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DateTime standardTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

        #region constructor

        public AccountController()
        {
        }

        #endregion constructor

        #region Login

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect(Url.Action("Index", "Home"));
            }

            ViewBag.ReturnUrl = returnUrl;           
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        /// <summary>
        /// Login  checks
        /// Added by YReddy on 12/10/2015
        /// </summary>    
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid User Name or Password");
                UserViewModel userViewModel = UserBL.GetUserByNameAndPassword(model.UserName, EncryptionHelper.EncryptPassword(model.Password));
                if (userViewModel != null)
                {
                    SetAuthentication(userViewModel, model.RememberMe);
                    return Redirect(Url.Action("Person", "Person"));
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User Name or Password");
                }
            }

            return View(model);
        }

        public ActionResult UnAuthorized()
        {
            return View();
        }
        #endregion Login

        #region SetAuthentication

        private void SetAuthentication(UserViewModel user, bool RememberMe)
        {
            UserContextViewModel userContext = new UserContextViewModel();
            //userContext.CurrentUser = CM;
            userContext.RoleName = user.RoleName;
            userContext.FullName = user.FullName;
            userContext.FirstName = user.FirstName;
            userContext.LastName = user.LastName;
            userContext.UserName = user.UserName;
            userContext.UserId = user.UserId;
            userContext.RoleId = user.RoleId;

            Session["CurrentUser"] = userContext;
            AuthenticationSerialize serialiseAuth = new AuthenticationSerialize();
            serialiseAuth.UserContext = userContext;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string userData = serializer.Serialize(serialiseAuth);

            var tenDaysFromNow = standardTime.AddDays(10);
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                            1,
                             serialiseAuth.UserContext.FullName + " " + serialiseAuth.UserContext.UserName,
                             standardTime,
                             tenDaysFromNow,
                            RememberMe,
                            userData);
            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            Response.Cookies.Add(faCookie);
        }

        /// <summary>
        /// Menu according to user
        /// </summary>
        /// <returns>Menu View</returns>
        public ActionResult Menu()
        {
            try
            {
                int roleId = 0;
                if (CurrentUser == null)
                    return Redirect(Url.Action("Login", "Account"));

                roleId = CurrentUser.RoleId;
                List<MenuViewModel> menuList = UserBL.GetMenuByRoleId(roleId, CurrentUser.UserId);
                return PartialView("_Menu", menuList);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion SetAuthentication

        #region LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            Session.Abandon();
            // Clear authentication cookie.
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie.Expires = standardTime.AddYears(-1);
            Response.Cookies.Add(cookie);
            HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Response.Cache.SetNoServerCaching();
            HttpContext.Response.Cache.SetNoStore();
            return RedirectToAction("Login", "Account");
        }

        #endregion LogOff
    }
}