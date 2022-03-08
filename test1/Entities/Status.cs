using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCar.Entities
{
    public class Status
    {
        [Required]
        [Display(Name = "Status Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Code Id")]
        public string Code { get; set; }

        [Required]
        [Display(Name = "Opis")]
        public string Opis { get; set; }

        public  IEnumerable<Rent> Rents { get; set; }
    }
}
