using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AACalc.Entity.ViewModel;
using AACalc.DAL.Data;


namespace AACalc.BAL
{
    public class CityBL : BaseBL
    {
       public static List<CityViewModel> GetAllCity()
       {
           List<tblCity> _citylist = new List<tblCity>();
           _citylist = _context.tblCities.ToList();


           List<CityViewModel> citylist = _citylist.ConvertAll(x => new CityViewModel
           {
               CityId = x.CityId,
               Name = x.Name,
               StateId = x.StateId
           });
           return citylist;
       }
    }
}
