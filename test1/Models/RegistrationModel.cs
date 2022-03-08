using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCar.Models
{
    public class RegistrationModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "User Name")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Ime")]
        public string Ime { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Prezime")]
        public string Prezime { get; set; }

        [Required]
        public string Adresa1 { get; set; }
        public string Adresa2 { get; set; }

   
        [Required]
        [RegularExpression(@"\d{10}")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public bool AcceptUserAgreement { get; set; }
        public string RegistrationInValid { get; set; }
        //public int CategoryId { get; set; }
    }
}
