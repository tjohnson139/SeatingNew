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
    public class DthsController : Controller
    {
        private readonly db_a7e17a_seatingContext _context;

        public DthsController(db_a7e17a_seatingContext context)
        {
            _context = context;
        }

        // GET: Dths
        public async Task<IActionResult> Index()
        {
            var db_a7e17a_seatingContext = _context.Dths.Where(d => d.TimeCleared == null);
            if (db_a7e17a_seatingContext != null)
            {
                return View(await db_a7e17a_seatingContext.ToListAsync());
            }
            ViewBag.FilteredDth = db_a7e17a_seatingContext.ToList();
            return View();
        }

        // GET: Dths/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dth = await _context.Dths
                .Include(d => d.EmpPositionNavigation)
                .Include(d => d.Employee)
                .Include(d => d.RlfPositionNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dth == null)
            {
                return NotFound();
            }

            return View(dth);
        }

        // GET: Dths/Create
        public IActionResult Create()
        {
            ViewData["EmpPosition"] = new SelectList(_context.Positions, "Id", "Id");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "DisplayName");
            ViewData["RlfPosition"] = new SelectList(_context.Positions, "Id", "Id");
            return View();
        }

        // POST: Dths/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TimeEntered,TimeCleared,EmpSent,EmployeeId,EmpPosition,RlfPosition")] Dth dth)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dth);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpPosition"] = new SelectList(_context.Positions, "Id", "Id", dth.EmpPosition);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "DisplayName", dth.EmployeeId);
            ViewData["RlfPosition"] = new SelectList(_context.Positions, "Id", "Id", dth.RlfPosition);
            return View(dth);
        }

        // GET: Dths/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dth = await _context.Dths.FindAsync(id);
            if (dth == null)
            {
                return NotFound();
            }
            ViewData["EmpPosition"] = new SelectList(_context.Positions, "Id", "Id", dth.EmpPosition);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "DisplayName", dth.EmployeeId);
            ViewData["RlfPosition"] = new SelectList(_context.Positions, "Id", "Id", dth.RlfPosition);
            return View(dth);
        }

        // POST: Dths/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TimeEntered,TimeCleared,EmpSent,EmployeeId,EmpPosition,RlfPosition")] Dth dth)
        {
            if (id != dth.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dth);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DthExists(dth.Id))
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
            ViewData["EmpPosition"] = new SelectList(_context.Positions, "Id", "Id", dth.EmpPosition);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "DisplayName", dth.EmployeeId);
            ViewData["RlfPosition"] = new SelectList(_context.Positions, "Id", "Id", dth.RlfPosition);
            return View(dth);
        }

        // GET: Dths/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dth = await _context.Dths
                .Include(d => d.EmpPositionNavigation)
                .Include(d => d.Employee)
                .Include(d => d.RlfPositionNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dth == null)
            {
                return NotFound();
            }

            return View(dth);
        }

        // POST: Dths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dth = await _context.Dths.FindAsync(id);
            _context.Dths.Remove(dth);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DthExists(int id)
        {
            return _context.Dths.Any(e => e.Id == id);
        }
    }
}
