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

        // GET: Lunches/Create
        public IActionResult Create()
        {
            ViewData["EmpPosition"] = new SelectList(_context.Positions, "Id", "Id");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "DisplayName");
            ViewData["ReasonId"] = new SelectList(_context.Reasons, "Id", "ReasonName");
            ViewData["RlfPosition"] = new SelectList(_context.Positions, "Id", "Id");
            return View();
        }

        // POST: Lunches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TimeEntered,TimeCleared,EmpSent,LunchTime,EmployeeId,ReasonId,EmpPosition,RlfPosition")] Lunch lunch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lunch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpPosition"] = new SelectList(_context.Positions, "Id", "Id", lunch.EmpPosition);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "DisplayName", lunch.EmployeeId);
            ViewData["ReasonId"] = new SelectList(_context.Reasons, "Id", "ReasonName", lunch.ReasonId);
            ViewData["RlfPosition"] = new SelectList(_context.Positions, "Id", "Id", lunch.RlfPosition);
            return View(lunch);
        }

        // GET: Lunches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lunch = await _context.Lunches.FindAsync(id);
            if (lunch == null)
            {
                return NotFound();
            }
            ViewData["EmpPosition"] = new SelectList(_context.Positions, "Id", "Id", lunch.EmpPosition);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "DisplayName", lunch.EmployeeId);
            ViewData["ReasonId"] = new SelectList(_context.Reasons, "Id", "ReasonName", lunch.ReasonId);
            ViewData["RlfPosition"] = new SelectList(_context.Positions, "Id", "Id", lunch.RlfPosition);
            return View(lunch);
        }

        // POST: Lunches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TimeEntered,TimeCleared,EmpSent,LunchTime,EmployeeId,ReasonId,EmpPosition,RlfPosition")] Lunch lunch)
        {
            if (id != lunch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lunch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LunchExists(lunch.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpPosition"] = new SelectList(_context.Positions, "Id", "Id", lunch.EmpPosition);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "DisplayName", lunch.EmployeeId);
            ViewData["ReasonId"] = new SelectList(_context.Reasons, "Id", "ReasonName", lunch.ReasonId);
            ViewData["RlfPosition"] = new SelectList(_context.Positions, "Id", "Id", lunch.RlfPosition);
            return View(lunch);
        }

        // GET: Lunches/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Lunches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lunch = await _context.Lunches.FindAsync(id);
            _context.Lunches.Remove(lunch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LunchExists(int id)
        {
            return _context.Lunches.Any(e => e.Id == id);
        }
    }
}
