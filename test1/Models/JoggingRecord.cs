using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RentaCar.Models
{
    public class JoggingRecord
    {
        public int Id { get; set; }

        public float Distance { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}