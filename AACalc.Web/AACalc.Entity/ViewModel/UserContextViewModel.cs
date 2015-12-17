using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AACalc.Entity.ViewModel
{
    /// <summary>
    /// UserContextViewModel class
    /// Added by YReddy on 12/10/2015
    /// </summary>
    [Serializable]
    public class UserContextViewModel
    {
        public ContextViewModel CurrentUser { get; set; }
        public string RoleName { get; set; }
        public string Password { set; get; }
        public List<string> Permisssion { get; set; }
        public String FullName { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public int UserId { get; set; }
        public String UserName { get; set; }
        public int RoleId { get; set; }
    }

    [Serializable]
    public class ContextViewModel
    {
        public int UserId { get; set; }
        public String UserName { get; set; }
        public int RoleId { get; set; }
    }
}
