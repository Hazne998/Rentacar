using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCar.Entities
{
    public class Proizvodjac
    {
        [Required]
        [Display(Name = "Proizvodjac ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ime")]
        public string Ime { get; set; }

        [Required]
        [Display(Name = "Detalji")]
        public string Detalji { get; set; }


        public IEnumerable<Model> Models { get; set; }

    }
}
