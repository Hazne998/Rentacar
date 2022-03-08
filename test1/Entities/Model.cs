using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCar.Entities
{
    public class Model
    {
        [Required]
        [Display(Name = "Model ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ime")]
        public string Ime { get; set; }

        [Required]
        [Display(Name = "Najam Po Danu")]
        public decimal NajamPoDanu { get; set; }

        [Required]
        [Display(Name = "Proizvodjac")]
        public int ProizvodjacId { get; set; }
        public Proizvodjac Proizvodjac { get; set; }

        public IEnumerable<Automobil> Automobils { get; set; }

    }
}
