using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCar.Entities
{
    public class ApplicationUser : IdentityUser
    {
  
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa1 { get; set; }
        public string Adresa2 { get; set; }
        public string PostCode { get; set; }

        public string ImePrezime => Ime + " " + Prezime;
        public IEnumerable<Rent> Rents { get; set; }
    }
}
