using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCar.Entities
{
    public class TipAutomobila
    {
        [Required]
        [Display(Name = "Tip ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tip")]
        public string Ime { get; set; }

        [Required]
        [Display(Name = "Opis")]
        public string Opis { get; set; }

        public IEnumerable<Automobil> Automobili { get; set; }

        public TipAutomobila() { }
    }
}
