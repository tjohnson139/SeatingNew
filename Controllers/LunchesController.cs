using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Seating.Models;

namespace Seating
{
    public class LunchesController : Controller
    {
        private readonly db_a7e17a_seatingContext _context;

        public LunchesController(db_a7e17a_seatingContext context)
        {
            _context = context;
        }

        // GET: Lunches
        public async Task<IActionResult> Index()
        {
            var db_a7e17a_seatingContext = _context.Lunches.Include(l => l.EmpPositionNavigation).Include(l => l.Employee).Include(l => l.Reason).Include(l => l.RlfPositionNavigation);
            return View(await db_a7e17a_seatingContext.ToListAsync());
        }

        // GET: Lunches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lunch = await _context.Lunches
                .Include(l => l.EmpPositionNavigation)
                .Include(l => l.Employee)
                .Include(l => l.Reason)
                .Include(l => l.RlfPositionNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lunch == null)
            {
                return NotFound();
            }

            return View(lunch);
        }

        // GET: Lunches/Delete/5
        [HttpPost]
        public async Task<ActionResult> DeleteLunch(int Id)
        {
            try
            {
                Lunch lunch = _context.Lunches.Find(Id);
                lunch.TimeCleared = DateTime.Now;
                await _context.SaveChangesAsync();

                return Json(new { success = true, });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }


        //Populates the dropdown list in the lunch override section of the main lunch page//
        public static List<string> getTimesOver()
        {
            List<string> times = new List<string>();
            var dt = DateTime.Now;
            if (dt.Hour >= 00 && dt.Hour < 01)
            {
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 05, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 05, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 06, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 06, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 07, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 07, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 08, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 08, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 00, 0).ToString("M/d/yy HH:mm"));
            }
            if (dt.Hour >= 01 && dt.Hour < 02)
            {
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 05, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 05, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 06, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 06, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 07, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 07, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 08, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 08, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 00, 0).ToString("M/d/yy HH:mm"));
            }
            if (dt.Hour >= 02 && dt.Hour < 03)
            {
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 05, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 05, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 06, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 06, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 07, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 07, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 08, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 08, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 00, 0).ToString("M/d/yy HH:mm"));
            }

            if (dt.Hour >= 03 && dt.Hour < 04)
            {
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 05, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 05, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 06, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 06, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 07, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 07, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 08, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 08, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 00, 0).ToString("M/d/yy HH:mm"));
            }

            if (dt.Hour >= 04 && dt.Hour < 05)
            {
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 05, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 05, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 06, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 06, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 07, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 07, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 08, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 08, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 00, 0).ToString("M/d/yy HH:mm"));
            }

            if (dt.Hour >= 05 && dt.Hour < 06)
            {
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 05, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 05, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 06, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 06, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 07, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 07, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 08, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 08, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 00, 0).ToString("M/d/yy HH:mm"));
            }

            if (dt.Hour >= 06 && dt.Hour < 07)
            {
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 06, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 06, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 07, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 07, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 08, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 08, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 00, 0).ToString("M/d/yy HH:mm"));
            }

            if (dt.Hour >= 07 && dt.Hour < 08)
            {
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 07, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 07, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 08, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 08, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 00, 0).ToString("M/d/yy HH:mm"));
            }
            if (dt.Hour >= 08 && dt.Hour < 09)
            {
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 08, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 08, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 00, 0).ToString("M/d/yy HH:mm"));
            }

            if (dt.Hour >= 09 && dt.Hour < 10)
            {
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 00, 0).ToString("M/d/yy HH:mm"));
            }
            if (dt.Hour >= 10 && dt.Hour < 11)

            {
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 00, 0).ToString("M/d/yy HH:mm"));
            }

            if (dt.Hour >= 11 && dt.Hour < 12)

            {
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 00, 0).ToString("M/d/yy HH:mm"));
            }

            if (dt.Hour >= 12 && dt.Hour < 13)

            {
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 12, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
            }

            if (dt.Hour >= 13 && dt.Hour < 14)

            {
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 13, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
            }

            if (dt.Hour >= 14 && dt.Hour < 15)

            {
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 14, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
            }

            if (dt.Hour >= 15 && dt.Hour < 16)

            {
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 15, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
            }

            if (dt.Hour >= 16 && dt.Hour < 17)

            {
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 16, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
            }

            if (dt.Hour >= 17 && dt.Hour < 18)

            {
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 17, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 05, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
            }

            if (dt.Hour >= 18 && dt.Hour < 19)

            {
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 18, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 05, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 05, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 06, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
            }

            if (dt.Hour >= 19 && dt.Hour < 20)

            {
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 19, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 05, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 05, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 06, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 06, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 07, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
            }

            if (dt.Hour >= 20 && dt.Hour < 21)

            {
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 20, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 05, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 05, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 06, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 06, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 07, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 07, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 08, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
            }

            if (dt.Hour >= 21 && dt.Hour < 22)

            {
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 21, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 05, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 05, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 06, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 06, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 07, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 07, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 08, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 08, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
            }

            if (dt.Hour >= 22 && dt.Hour < 23)

            {
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 22, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 05, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 05, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 06, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 06, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 07, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 07, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 08, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 08, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
            }

            if (dt.Hour == 23)

            {
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 00, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 23, 30, 0).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 00, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 01, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 02, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 03, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 04, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 05, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 05, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 06, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 06, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 07, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 07, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 08, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 08, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 09, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 10, 30, 0).AddDays(1).ToString("M/d/yy HH:mm"));
                times.Add(new DateTime(dt.Year, dt.Month, dt.Day, 11, 00, 0).AddDays(1).ToString("M/d/yy HH:mm"));
            }


            return times;

        }
    }
}
