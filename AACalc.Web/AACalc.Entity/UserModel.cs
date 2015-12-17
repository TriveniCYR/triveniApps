using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AACalc.Entity
{
    [DataContract]
    public class UserModel
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public String UserName { get; set; }

        [DataMember]
        public string Password { set; get; }

        public bool IsActive { get; set; }

        [DataMember]
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public string TeamName { get; set; }

        [DataMember]
        public int TeamId { get; set; }

        public int CreatedBy { get; set; }

        public string CreatedOn { get; set; }

        public int? DeletedBy { get; set; }

        public string DeletedOn { get; set; }

        public string UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
