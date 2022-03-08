using RentaCar.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCar.Entities
{
    public class Rent
    {
        

        [Display(Name = "Rent ID")]
        public int RentId { get; set; }

        [Display(Name = "Datum pocetka")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DatumPocetka { get; set; }

        [Display(Name = "Datum zavrsetka")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DatumZavrsetka { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int AutomobilId { get; set; }
        public Automobil Automobil { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }



        public bool CheckDate()
        {
            if (this.DatumPocetka <= this.DatumZavrsetka && this.DatumPocetka >= DateTime.Now.Date && this.DatumZavrsetka >= DateTime.Now.Date)
            {
                return true;
            }
            return false;
        }
    }
}
