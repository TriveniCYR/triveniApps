using AACalc.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AACalc.Web.Controllers
{
    /// <summary>
    /// Base Controller
    /// Added by YReddy on 12/10/2015
    /// </summary>
    public class BaseController : Controller
    {
        public UserContextViewModel CurrentUser
        {
            get
            { 
                if (Session["CurrentUser"] != null)
                    return (UserContextViewModel)Session["CurrentUser"];
                return null;
            }
        }
    }
}