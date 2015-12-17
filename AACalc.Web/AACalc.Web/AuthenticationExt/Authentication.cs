using AACalc.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace AACalc.Web.AuthenticationExt
{
    /// <summary>
    /// Authentication class
    /// Added by YReddy on 12/10/2015
    /// </summary>    
    public class Authentication : IAuthentication
    {
        public Authentication()
        {

        }
        public IIdentity Identity { get; private set; }

        public Authentication(string email)
        {
            this.Identity = new GenericIdentity(email);
        }
        
        public UserContextViewModel UserContext
        {
            get; set;
        }

        public bool IsInRole(string permissions)
        {
            if ((UserContext != null))
            {
                string[] roleArray = permissions.Split(',');
                for (int i = 0; i < roleArray.Length; i++)
                {
                    var isContain = UserContext.Permisssion.Contains(roleArray[i]);
                    if (isContain)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }

    public class AuthenticationSerialize
    {
        public UserContextViewModel UserContext
        {
            get;
            set;
        }

    }
}