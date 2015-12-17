using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AACalc.Entity.ViewModel
{
    public class UserViewModel : UserContextViewModel
    {
        [Required(ErrorMessage = "User name is required")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Password")]
        public string Password { set; get; }

        [Required(ErrorMessage = "Please select role")]
        [Display(Name = "Role")]
        public int RoleId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int? CreatedBy { get; set; }
    }

    public class UserTeamLogViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string OldTeam { get; set; }
        public string NewTeam { get; set; }
    }
}
