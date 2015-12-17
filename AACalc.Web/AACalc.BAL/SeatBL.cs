using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AACalc.Entity.ViewModel;
using AACalc.DAL.Data;

namespace AACalc.BAL
{
   public class SeatBL:BaseBL
    {

       public static List<SeatViewModel> GetAllSeats()
       {
           List<tblSeat> _Seatslist = new List<tblSeat>();
           _Seatslist = _context.tblSeats.ToList();


           List<SeatViewModel> Seatslist = _Seatslist.ConvertAll(x => new SeatViewModel
           {
               SeatId = x.SeatId,
               SeatCode = x.SeatCode
           });
           return Seatslist;
       }
    }
}
