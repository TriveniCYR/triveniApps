using AACalc.Common.Helper;
using AACalc.DAL.Data;
using AACalc.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AACalc.BAL
{
    /// <summary>
    /// Used to handle all Person related transactions
    /// Added by YReddy on 12/06/2015
    /// </summary>
    public class PersonBL : BaseBL
    { 
        public static int CreateNewPerson(PersonViewModel objPersonViewModel)
        {
            tblPerson _tblperson = GetPersonEntityfromPerson(objPersonViewModel);
            _context.tblPersons.Add(_tblperson);
            _context.SaveChanges();
            return _tblperson.PersonId;
        }

        public static int UpdatePerson(PersonViewModel objPersonViewModel)
        {
            tblPerson _tblperson = GetPersonEntityfromPerson(objPersonViewModel);
            _context.Entry(_tblperson).State=EntityState.Modified;
            _context.SaveChanges();
            return _tblperson.PersonId;
        }

        public static List<PersonViewModel> GetAllPersons()
        {
            List<tblPerson> _listPerson = _context.tblPersons.ToList();
            var lstPersons = GetPersonsfromPersonEntityList(_listPerson);

            return lstPersons;
        }











        /// <summary>
        /// Getting List of Person from DB
        /// Added by YReddy on 12/06/2015
        /// </summary>
        /// <returns>PersonViewModel List</returns>
       

        /// <summary>
        /// Getting single Person Details by ID
        /// Added by YReddy on 12/06/2015
        /// </summary>
        /// <param name="personID">personID</param>
        /// <returns>Person ViewModel</returns>
        //public static PersonViewModel GetPersonByID(int personID)
        //{
        //    tblPerson _person = _context.tblPersons.Where(x => x.PersonId == personID).FirstOrDefault();
        //    var person = GetPersonsfromPersonEntityList(_person);

        //    return person;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objPerson"></param>
        /// <returns></returns>
        //public static bool CreatePersonWithAddress(PersonViewModel objPerson)
        //{
        //    try
        //    {
        //        int personId = CreatePerson(objPerson);
        //        objPerson.PersonId = personId;

        //        AddressBL.CreateNewAddress(objPerson);
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        /// <summary>
        /// Create & Saving New Person into system
        /// Added by YReddy on 12/06/2015
        /// </summary>
        /// <param name="objPerson">Person ViewModel</param>
        /// <returns>Person ID</returns>
        //public static int CreatePerson(PersonViewModel objPerson)
        //{
        //    tblPerson _tblperson = GetPersonEntityfromPerson(objPerson); 
        //    _context.tblPersons.Add(_tblperson);
        //    _context.SaveChanges();
        //    return _tblperson.PersonId;
        //}

        /// <summary>
        /// Generating Person View Model List from tbl Person list
        /// Added by YReddy on 12/06/2015
        /// </summary>
        /// <param name="tblPersonsList"></param>
        /// <returns>Person ViewModel list</returns>
        protected static List<PersonViewModel> GetPersonsfromPersonEntityList(List<tblPerson> tblPersonsList)
        {
            var lstPersons = new List<PersonViewModel>();
            foreach (var tblPerson in tblPersonsList)
            {
                var person = GetPersonsfromPersonEntityList(tblPerson);

                lstPersons.Add(person);
            }
            return lstPersons;
        }

        /// <summary>
        /// Generating Person View Model from tbl Person
        /// Added by YReddy on 12/06/2015
        /// </summary>
        /// <param name="tblPerson">Person Entity</param>
        /// <returns>Person ViewModel</returns>
        protected static PersonViewModel GetPersonsfromPersonEntityList(tblPerson tblPerson)
        {
            var person = new PersonViewModel()
            {
                PersonId = tblPerson.PersonId,
                AltRetireDate = tblPerson.AltRetireDate,
                AveFlyHours = tblPerson.AveFlyHours,
                DOB = tblPerson.DOB,
                EquipmentID = tblPerson.EquipmentID,
                FirstName = tblPerson.FirstName,
                LastName = tblPerson.LastName,
                SeatId = tblPerson.SeatId,
                SpouseDOB = tblPerson.SpouseDOB,
                SpouseFirstName = tblPerson.SpouseFirstName,
                SpouseLastName = tblPerson.SpouseLastName,
                CreatedBy = tblPerson.CreatedBy,
                CreatedDate = tblPerson.CreatedDate,
                UpdatedBy = tblPerson.UpdatedBy,
                UpdatedDate = tblPerson.UpdatedDate
            };
            return person;
        }

        /// <summary>
        /// Generating tbl Person from Person View Model
        /// Added by YReddy on 12/06/2015
        /// </summary>
        /// <param name="personView">Person ViewModel</param>
        /// <returns>Person Entity</returns>
        protected static tblPerson GetPersonEntityfromPerson(PersonViewModel personView)
        {
            var tblPerson = new tblPerson()
            {
                PersonId = personView.PersonId,
                AltRetireDate = personView.AltRetireDate,
                AveFlyHours = personView.AveFlyHours,
                DOB = personView.DOB,
                EquipmentID = personView.EquipmentID,
                FirstName = personView.FirstName,
                LastName = personView.LastName,
                SeatId = personView.SeatId,
                SpouseDOB = personView.SpouseDOB,
                SpouseFirstName = personView.SpouseFirstName,
                SpouseLastName = personView.SpouseLastName,
                CreatedBy = personView.CreatedBy,
                CreatedDate = personView.PersonId != 0 ? personView.CreatedDate : DateTime.Now,
                UpdatedBy = personView.UpdatedBy,
                UpdatedDate = personView.PersonId != 0 ? personView.UpdatedDate : DateTime.Now,
            };
            return tblPerson;
        }
    }
}
