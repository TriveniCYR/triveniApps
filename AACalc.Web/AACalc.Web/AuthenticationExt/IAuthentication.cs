using AACalc.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace AACalc.Web.AuthenticationExt
{
    /// <summary>
    /// IAuthentication interface
    /// Added by YReddy on 12/10/2015
    /// </summary>
    interface IAuthentication : IPrincipal
    {
        UserContextViewModel UserContext { get; set; }
    }
}