using AACalc.BAL;
using AACalc.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AACalc.Web.Controllers
{
    public class PersonController : BaseController
    {
        public ActionResult Search()
        {
            var personsList = PersonBL.GetAllPersons();
            return View(personsList);
        }
              

        [HttpGet]
        public ActionResult Person(int? id)
        {
            if (CurrentUser == null)
                return Redirect(Url.Action("Login", "Account"));

            ComplexViewModel objComplexViewModel = new ComplexViewModel();
            objComplexViewModel.PersonViewModel = new PersonViewModel();
            objComplexViewModel.PersonFinancialViewModel = new PersonFinancialViewModel();
            objComplexViewModel.AddressViewModel = new AddressViewModel();

            objComplexViewModel.PersonViewModel = PersonBL.GetAllPersons().Where(x => x.PersonId == id).FirstOrDefault();
            objComplexViewModel.PersonFinancialViewModel = FinancialBL.GetAllPersonFinancial().Where(x => x.CustomerId == id).FirstOrDefault();
            objComplexViewModel.AddressViewModel = AddressBL.GetAllPersonAddress().Where(x => x.PersonId == id).FirstOrDefault();


            //State Dropdownist
            var StateList = new SelectList(StateBL.GetAllState().Select(s => new { s.StateId, s.Name }), "StateId", "Name");
            ViewBag.StateList = StateList;

            //City Dropdownlist
            var CityList = new SelectList(CityBL.GetAllCity().Where(x => x.StateId == (objComplexViewModel.AddressViewModel == null ? 0 : objComplexViewModel.AddressViewModel.StateId)).ToList().Select(s => new { s.CityId, s.Name }), "CityId", "Name");
            ViewBag.CityList = CityList;

            //Equipment Dropdownlist
            var EquipmentList = new SelectList(EquipmentBL.GetAllEquipment().ToList().Select(s => new { s.EquipmentId, s.Name }), "EquipmentId", "Name");
            ViewBag.EquipmentList = EquipmentList;

            //Seats Dropdownlist
            var SeatsList = new SelectList(SeatBL.GetAllSeats().ToList().Select(s => new { s.SeatId, s.SeatCode }), "SeatId", "SeatCode");
            ViewBag.SeatsList = SeatsList;


            return View(objComplexViewModel);
        }
        [HttpPost]
        public ActionResult Person(ComplexViewModel objComplexViewModel)
        {
            if (objComplexViewModel.PersonViewModel.PersonId == 0)
            {
                int PersonId = PersonBL.CreateNewPerson(objComplexViewModel.PersonViewModel);
                objComplexViewModel.AddressViewModel.PersonId = PersonId;
                objComplexViewModel.PersonFinancialViewModel.CustomerId = PersonId;
                AddressBL.CreateNewPersonAddress(objComplexViewModel.AddressViewModel);
                FinancialBL.CreateNewPersonFinancial(objComplexViewModel.PersonFinancialViewModel);

            }
            else
            {
                PersonBL.UpdatePerson(objComplexViewModel.PersonViewModel);
                AddressBL.UpdatePersonAddress(objComplexViewModel.AddressViewModel);
                FinancialBL.UpdatePersonFinancial(objComplexViewModel.PersonFinancialViewModel);

            }
            return View();
        }

         [HttpPost]
        public JsonResult GetCityByStateId(string StateId)
        {
           
            int CovertStateID;
            bool res = int.TryParse(StateId, out CovertStateID);
            if (res == false)
            {
                CovertStateID = 0;
            }

            List<CityViewModel> citylist = CityBL.GetAllCity().Where(x => x.StateId == CovertStateID).ToList();

            return Json(citylist);
        }
    }
}