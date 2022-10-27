using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUsData.Entities
{
    [Table("tbl_customers")]
    public class Customer : BaseEntity<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string PhoneNo { get; set; }
        public bool Active { get; set; }
        public bool IsCustomerAffiliate { get; set; }
        public bool IsCustomerAnEmployee { get; set; }
        public string Gender { get; set; } //Male,Female
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int TenantID { get; set; }
        public bool isDeleted { get; set; }
    }
}
