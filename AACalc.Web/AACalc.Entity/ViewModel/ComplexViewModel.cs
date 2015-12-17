using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AACalc.Entity.ViewModel
{
    public class ComplexViewModel
    {
        public PersonViewModel PersonViewModel { get; set; }
        public AddressViewModel AddressViewModel { get; set; }
        public PersonFinancialViewModel PersonFinancialViewModel { get; set; }
    }
}
