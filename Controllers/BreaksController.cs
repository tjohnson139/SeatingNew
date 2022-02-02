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
    public class BreaksController : Controller
    {
        private readonly db_a7e17a_seatingContext _context;

        public BreaksController(db_a7e17a_seatingContext context)
        {
            _context = context;
        }

        // GET: Breaks
        public async Task<IActionResult> Index()
        {
            var db_a7e17a_seatingContext = _context.Breaks.Include(n => n.EmpPositionNavigation).Include(n => n.Employee).Include(n => n.RlfPositionNavigation);
            return View(await db_a7e17a_seatingContext.ToListAsync());
        }

        // GET: Breaks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @break = await _context.Breaks
                .Include(n => n.EmpPositionNavigation)
                .Include(n => n.Employee)
                .Include(n => n.RlfPositionNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@break == null)
            {
                return NotFound();
            }

            return View(@break);
        }

        // GET: Breaks/Create
        public IActionResult Create()
        {
            ViewData["EmpPosition"] = new SelectList(_context.Positions, "Id", "PositionName");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "DisplayName");
            ViewData["RlfPosition"] = new SelectList(_context.Positions, "Id", "PositionName");
            return View();
        }

        // POST: Breaks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TimeEntered,TimeCleared,EmpSent,EmployeeId,EmpPosition,RlfPosition")] Break @break)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@break);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpPosition"] = new SelectList(_context.Positions, "Id", "PositionName", @break.EmpPosition);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "DisplayName", @break.EmployeeId);
            ViewData["RlfPosition"] = new SelectList(_context.Positions, "Id", "PositionName", @break.RlfPosition);
            return View(@break);
        }

        // GET: Breaks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @break = await _context.Breaks.FindAsync(id);
            if (@break == null)
            {
                return NotFound();
            }
            ViewData["EmpPosition"] = new SelectList(_context.Positions, "Id", "PositionName", @break.EmpPosition);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "DisplayName", @break.EmployeeId);
            ViewData["RlfPosition"] = new SelectList(_context.Positions, "Id", "PositionName", @break.RlfPosition);
            return View(@break);
        }

        // POST: Breaks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TimeEntered,TimeCleared,EmpSent,EmployeeId,EmpPosition,RlfPosition")] Break @break)
        {
            if (id != @break.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@break);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BreakExists(@break.Id))
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
            ViewData["EmpPosition"] = new SelectList(_context.Positions, "Id", "PositionName", @break.EmpPosition);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "DisplayName", @break.EmployeeId);
            ViewData["RlfPosition"] = new SelectList(_context.Positions, "Id", "PositionName", @break.RlfPosition);
            return View(@break);
        }

        // GET: Breaks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @break = await _context.Breaks
                .Include(n => n.EmpPositionNavigation)
                .Include(n => n.Employee)
                .Include(n => n.RlfPositionNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@break == null)
            {
                return NotFound();
            }

            return View(@break);
        }

        // POST: Breaks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @break = await _context.Breaks.FindAsync(id);
            _context.Breaks.Remove(@break);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BreakExists(int id)
        {
            return _context.Breaks.Any(e => e.Id == id);
        }
    }
}
