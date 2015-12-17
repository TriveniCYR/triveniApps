using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AACalc.Entity.ViewModel
{
    public class PersonViewModel
    {
        public int PersonId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string SpouseFirstName { get; set; }
        public string SpouseLastName { get; set; }
        public DateTime? SpouseDOB { get; set; }
        public int EquipmentID { get; set; }
        public int SeatId { get; set; }
        public int AveFlyHours { get; set; }
        public int YearOfCreditService { get; set; }
        public DateTime? AltRetireDate { get; set; }

        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public string ZipCode { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }


        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
