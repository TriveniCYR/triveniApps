using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AACalc.Entity.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username field is required")]
        [Display(Name = "Username")]
        public string UserName { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password field is required")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
