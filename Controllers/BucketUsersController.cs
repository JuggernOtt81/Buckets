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
    public class BucketUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BucketUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BucketUsers
        public async Task<IActionResult> Index()
        {
              return View(await _context.BucketUser.ToListAsync());
        }

        // GET: BucketUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.BucketUser == null)
            {
                return NotFound();
            }

            var bucketUser = await _context.BucketUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bucketUser == null)
            {
                return NotFound();
            }

            return View(bucketUser);
        }

        // GET: BucketUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BucketUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PrimaryAccount,NetWorth,TotalDebt")] BucketUser bucketUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bucketUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bucketUser);
        }

        // GET: BucketUsers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.BucketUser == null)
            {
                return NotFound();
            }

            var bucketUser = await _context.BucketUser.FindAsync(id);
            if (bucketUser == null)
            {
                return NotFound();
            }
            return View(bucketUser);
        }

        // POST: BucketUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName,LastName,PrimaryAccount,NetWorth,TotalDebt")] BucketUser bucketUser)
        {
            if (id != bucketUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bucketUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BucketUserExists(bucketUser.Id))
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
            return View(bucketUser);
        }

        // GET: BucketUsers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.BucketUser == null)
            {
                return NotFound();
            }

            var bucketUser = await _context.BucketUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bucketUser == null)
            {
                return NotFound();
            }

            return View(bucketUser);
        }

        // POST: BucketUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.BucketUser == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BucketUser'  is null.");
            }
            var bucketUser = await _context.BucketUser.FindAsync(id);
            if (bucketUser != null)
            {
                _context.BucketUser.Remove(bucketUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BucketUserExists(string id)
        {
          return _context.BucketUser.Any(e => e.Id == id);
        }
    }
}
