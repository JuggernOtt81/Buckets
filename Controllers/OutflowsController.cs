using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Buckets.Data;
using Buckets.Models;

namespace Buckets.Controllers
{
    public class OutflowsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OutflowsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Outflows
        public async Task<IActionResult> Index()
        {
              return View(await _context.Outflow.ToListAsync());
        }

        // GET: Outflows/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Outflow == null)
            {
                return NotFound();
            }

            var outflow = await _context.Outflow
                .FirstOrDefaultAsync(m => m.Id == id);
            if (outflow == null)
            {
                return NotFound();
            }

            return View(outflow);
        }

        // GET: Outflows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Outflows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Amount")] Outflow outflow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(outflow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(outflow);
        }

        // GET: Outflows/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Outflow == null)
            {
                return NotFound();
            }

            var outflow = await _context.Outflow.FindAsync(id);
            if (outflow == null)
            {
                return NotFound();
            }
            return View(outflow);
        }

        // POST: Outflows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Description,Amount")] Outflow outflow)
        {
            if (id != outflow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(outflow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OutflowExists(outflow.Id))
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
            return View(outflow);
        }

        // GET: Outflows/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Outflow == null)
            {
                return NotFound();
            }

            var outflow = await _context.Outflow
                .FirstOrDefaultAsync(m => m.Id == id);
            if (outflow == null)
            {
                return NotFound();
            }

            return View(outflow);
        }

        // POST: Outflows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Outflow == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Outflow'  is null.");
            }
            var outflow = await _context.Outflow.FindAsync(id);
            if (outflow != null)
            {
                _context.Outflow.Remove(outflow);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OutflowExists(string id)
        {
          return _context.Outflow.Any(e => e.Id == id);
        }
    }
}
