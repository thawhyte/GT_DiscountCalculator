using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUsModel.DTOs.CustomerDTOs
{
    public class CreateCustomerDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNo { get; set; }
        public bool Active { get; set; }
        public bool IsCustomerAffiliate { get; set; }
        public bool IsCustomerAnEmployee { get; set; }
        [Required]
        public string Gender { get; set; } //Male,Female

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }
    }
}
