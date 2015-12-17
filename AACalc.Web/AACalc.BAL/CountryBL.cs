using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AACalc.Entity.ViewModel;
using AACalc.DAL.Data;

namespace AACalc.BAL
{
   public class CountryBL:BaseBL
    {
       public static List<CountryViewModel> GetAllCountry()
       {
           List<tblCountry> _countrylist =new List<tblCountry>();
           _countrylist = _context.tblCountries.ToList();

          
           List<CountryViewModel> citylist = _countrylist.ConvertAll(x => new CountryViewModel
           {
               CountryId = x.CountryId,
               Name = x.Name
           });  
           return citylist;
       }
       
    }
}
