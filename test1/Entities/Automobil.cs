using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCar.Entities
{
    public class Automobil
    {
        public Automobil()
        {
        }

        [Required]
        [Display(Name = "Auto ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tablice automobila")]
        public string Tablice { get; set; }

        [Required]
        [Display(Name = "Model")]
        public int ModelId { get; set; }
        public Model Model { get; set; }

        [Required]
        [Display(Name = "Tip automobila")]
        public int TipAutomobilaId { get; set; }
        public TipAutomobila TipAutomobila { get; set; }

        [Required]
        [Display(Name = "Lokacija")]
        public int LokacijaId { get; set; }
        public Lokacija Lokacija { get; set; }

        public IEnumerable<Rent> Rents { get; set; }

    }
}
