using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AACalc.Entity.ViewModel;
using AACalc.DAL.Data;

namespace AACalc.BAL
{
   public class EquipmentBL:BaseBL
    {
       public static List<EquipmentViewModel> GetAllEquipment()
       {
           List<tblEquipment> _Equipmentlist = new List<tblEquipment>();
           _Equipmentlist = _context.tblEquipments.ToList();


           List<EquipmentViewModel> Equipmentlist = _Equipmentlist.ConvertAll(x => new EquipmentViewModel
           {
               EquipmentId = x.EquipmentId,
               Name = x.Name
           });
           return Equipmentlist;
       }
       
    }
}
