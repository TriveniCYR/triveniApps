using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AACalc.Entity.ViewModel
{
    /// <summary>
    /// Menu ViewModel
    /// Added by YReddy on 12/10/2015
    /// </summary>
    public  class MenuViewModel
    {
        public int MenuId { get; set; }
        public string CssClass { get; set; }
        public int DisplayOrder { get; set; }
        public string MenuName { get; set; }
        public string URL { get; set; }
    }
}
