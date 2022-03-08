using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCar.Entities
{
    public class Lokacija
    {
        [Required]
        [Display(Name = "Lokacija Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Code ")]
        public string Code { get; set; }

        [Required]
        [Display(Name = "Ime")]
        public string Ime { get; set; }


        public IEnumerable<Automobil> Automobils { get; set; }
    }
}
