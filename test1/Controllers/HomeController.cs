using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using RentaCar.Models;
using RentaCar.Entities;
using RentaCar.Data;
using Microsoft.AspNetCore.Identity;

namespace RentaCar.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ApplicationDbContext _db;
        private UserManager<ApplicationUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _db = db;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }

       

        public IActionResult Chat()
        {
            return View();
        }


        
        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
