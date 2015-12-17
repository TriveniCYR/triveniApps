using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AACalc.Entity.ViewModel;
using AACalc.DAL.Data;


namespace AACalc.BAL
{
   public class StateBL:BaseBL
    {

       public static List<StateViewModel> GetAllState()
       {
           List<tblState> _Statelist = new List<tblState>();
           _Statelist = _context.tblStates.ToList();


           List<StateViewModel> statelist = _Statelist.ConvertAll(x => new StateViewModel
           {
               StateId = x.StateId,
               Name = x.Name
           });
           return statelist;
       }
    }
}
