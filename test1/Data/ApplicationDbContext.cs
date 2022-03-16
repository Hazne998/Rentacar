using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentaCar.Entities;
using RentaCar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace RentaCar.Data
{
    

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {     
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Automobil> Automobils { get; set; }

        public DbSet<Proizvodjac> Proizvodjacs { get; set; }
        public DbSet<Lokacija> Lokacijas { get; set; }

        public DbSet<Model> Models { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<TipAutomobila> TipAutomobilas { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


    }
}
