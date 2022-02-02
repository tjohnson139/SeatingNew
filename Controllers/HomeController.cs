using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Seating.Models;
using Seating.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Seating.Controllers
{
    public class HomeController : Controller
    {
        private readonly db_a7e17a_seatingContext _context = new db_a7e17a_seatingContext();

        public HomeController(db_a7e17a_seatingContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var tables = new ListsVM
            {
                Employees = _context.Employees.ToList(),
                Dths = _context.Dths.Where(n => n.TimeCleared == null).OrderBy(n => n.TimeEntered).ToList(),
                Breaks = _context.Breaks.Where(n => n.TimeCleared == null).OrderBy(n => n.TimeEntered).ToList(),
                Lunches = _context.Lunches.Where(n => n.TimeCleared == null).OrderBy(n => n.LunchTime).ToList(),
                Positions = _context.Positions.ToList()
            };

            //Controls what populates the "off the floor" number on the home page
            TimeSpan time = DateTime.Now.TimeOfDay;

            var fireCounted = new bool();

            if (time > new TimeSpan(00, 00, 00) && time < new TimeSpan(10, 00, 00))
            {
                fireCounted = true;
            }

            ViewData["offFloor"] = tables.Breaks.Where(n => n.TimeCleared == null && n.EmpSent == true).Count() + tables.Dths.Where(n => n.EmpSent == true && n.TimeCleared == null).Count() + tables.Lunches.Where(n => n.EmpSent == true && n.TimeCleared == null && (fireCounted.Equals(true) || (fireCounted.Equals(false) && n.EmpPositionNavigation.PositionName != "FR" && n.EmpPositionNavigation.PositionName != "FL" && n.EmpPositionNavigation.PositionName != "FC"))).Count();

            ViewData["fireCounted"] = fireCounted;

            return View(tables);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
