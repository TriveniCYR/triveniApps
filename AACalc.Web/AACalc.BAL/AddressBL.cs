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
    public class AddressBL : BaseBL
    {


        public static int CreateNewPersonAddress(AddressViewModel objAddressViewModel)
        {
            tblAddress _tblAddress = GettblAddressEntityfromAddressViewModel(objAddressViewModel);
            _context.tblAddresses.Add(_tblAddress);
            _context.SaveChanges();
            return _tblAddress.AddressId;
        }

        public static int UpdatePersonAddress(AddressViewModel objAddressViewModel)
        {
            tblAddress _tblAddress = GettblAddressEntityfromAddressViewModel(objAddressViewModel);
            _context.Entry(_tblAddress).State = EntityState.Modified;
            _context.SaveChanges();
            return _tblAddress.AddressId;
        }


        public static List<AddressViewModel> GetAllPersonAddress()
        {
            List<tblAddress> _listPersonAddress = _context.tblAddresses.ToList();
            var lstPersons = GetAddressfromAddressEntityList(_listPersonAddress);

            return lstPersons;
        }

        protected static List<AddressViewModel> GetAddressfromAddressEntityList(List<tblAddress> tblAddressList)
        {
            var lstAddress = new List<AddressViewModel>();
            foreach (var tblAddress in tblAddressList)
            {
                var Address = GetAddressViewModelfromtblAddressEntity(tblAddress);

                lstAddress.Add(Address);
            }
            return lstAddress;
        }



        protected static tblAddress GettblAddressEntityfromAddressViewModel(AddressViewModel AddressView)
        {
            var tblAddress = new tblAddress()
            {
                PersonId = AddressView.PersonId,
                AddressId = AddressView.AddressId,
                AddressLine1 = AddressView.AddressLine1,
                AddressLine2 = AddressView.AddressLine2,
                City = AddressView.City,
                Email = AddressView.Email,
                Fax = AddressView.Fax,
                HomePhone = AddressView.HomePhone,
                MobilePhone = AddressView.MobilePhone,
                StateId = AddressView.StateId,
                ZipCode = AddressView.ZipCode,
                CreatedBy = AddressView.CreatedBy,
                CreatedDate = AddressView.PersonId != 0 ? AddressView.CreatedDate : DateTime.Now,
                UpdatedBy = AddressView.UpdatedBy,
                UpdatedDate = AddressView.PersonId != 0 ? AddressView.UpdatedDate : DateTime.Now,
            };
            return tblAddress;
        }

        protected static AddressViewModel GetAddressViewModelfromtblAddressEntity(tblAddress AddressView)
        {
            var tblAddress = new AddressViewModel()
            {
                PersonId = AddressView.PersonId,
                AddressId = AddressView.AddressId,
                AddressLine1 = AddressView.AddressLine1,
                AddressLine2 = AddressView.AddressLine2,
                City = AddressView.City,
                Email = AddressView.Email,
                Fax = AddressView.Fax,
                HomePhone = AddressView.HomePhone,
                MobilePhone = AddressView.MobilePhone,
                StateId = AddressView.StateId,
                ZipCode = AddressView.ZipCode,
                CreatedBy = AddressView.CreatedBy,
                CreatedDate = AddressView.PersonId != 0 ? AddressView.CreatedDate : DateTime.Now,
                UpdatedBy = AddressView.UpdatedBy,
                UpdatedDate = AddressView.PersonId != 0 ? AddressView.UpdatedDate : DateTime.Now,
            };
            return tblAddress;
        }





       









        /// <summary>
        /// Creating New Address for Person
        ///  Added by YReddy on 12/06/2015
        /// </summary>
        /// <param name="addressView">Address ViewModel</param>
        /// <param name="_context">AACalculatorEntities</param>
        /// <returns>True/False</returns>
        //public static bool CreateAddress(AddressViewModel addressView)
        //{
        //    if (_context == null)
        //        _context = new AACalculatorEntities();

        //    tblAddress _address = GetAddressEntityFromAddessViewModel(addressView);
        //    _context.tblAddresses.Add(_address);
        //    _context.SaveChanges();
        //    return true;
        //}

        /// <summary>
        /// Creating New Address for Person
        ///  Added by YReddy on 12/06/2015
        /// </summary>
        /// <param name="addressView">Person ViewModel</param>
        /// <param name="_context">AACalculatorEntities</param>
        /// <returns>True/False</returns>
        //public static bool CreateNewAddress(PersonViewModel addressView)
        //{
        //    if (_context == null)
        //        _context = new AACalculatorEntities();

        //    tblAddress _address = GetAddressEntityFromPersonViewModel(addressView);
        //    _context.tblAddresses.Add(_address);
        //    _context.SaveChanges();
        //    return true;
        //}


        /// <summary>
        /// Generating Address Entity from Address View Model
        /// Added by YReddy on 12/06/2015
        /// </summary>
        /// <param name="address">Address ViewModel</param>
        /// <returns>Address Entity</returns>
        //protected static tblAddress GetAddressEntityFromAddessViewModel(AddressViewModel address)
        //{
        //    var person = new tblAddress()
        //    {
        //        AddressId = address.AddressId,
        //        AddressLine1 = address.AddressLine1,
        //        AddressLine2 = address.AddressLine2,
        //        City = address.City,
        //        Email = address.Email,
        //        Fax = address.Fax,
        //        HomePhone = address.HomePhone,
        //        MobilePhone = address.MobilePhone,
        //        PersonId = address.PersonId,
        //        StateId = address.StateId,
        //        ZipCode = address.ZipCode,
        //        CreatedBy = address.CreatedBy,
        //        CreatedDate = DateTime.Now,
        //        UpdatedBy = address.UpdatedBy,
        //        UpdatedDate = DateTime.Now,
        //    };
        //    return person;
        //}

        /// <summary>
        /// Generating Address Entity from Address View Model
        /// Added by YReddy on 12/06/2015
        /// </summary>
        /// <param name="address">Person ViewModel</param>
        /// <returns>Address Entity</returns>
        //protected static tblAddress GetAddressEntityFromPersonViewModel(PersonViewModel address)
        //{
        //    var person = new tblAddress()
        //    {
        //        AddressId = address.AddressId,
        //        AddressLine1 = address.AddressLine1,
        //        AddressLine2 = address.AddressLine2,
        //        City = address.City,
        //        Email = address.Email,
        //        Fax = address.Fax,
        //        HomePhone = address.HomePhone,
        //        MobilePhone = address.MobilePhone,
        //        PersonId = address.PersonId,
        //        StateId = address.StateId,
        //        ZipCode = address.ZipCode,
        //        CreatedBy = address.CreatedBy,
        //        CreatedDate = DateTime.Now,
        //        UpdatedBy = address.UpdatedBy,
        //        UpdatedDate = DateTime.Now,
        //    };
        //    return person;
        //}






    }
}
