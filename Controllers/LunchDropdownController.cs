using Microsoft.AspNetCore.Mvc;
using Seating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seating.Controllers
{
    public class LunchDropdownController : Controller
    {

        private static db_a7e17a_seatingContext _context = new db_a7e17a_seatingContext();

        public LunchDropdownController(db_a7e17a_seatingContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}
