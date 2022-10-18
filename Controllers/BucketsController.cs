﻿using System;
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
    public class BucketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BucketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Buckets
        public async Task<IActionResult> Index()
        {
              return View(await _context.Bucket.ToListAsync());
        }

        // GET: Buckets/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Bucket == null)
            {
                return NotFound();
            }

            var bucket = await _context.Bucket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bucket == null)
            {
                return NotFound();
            }

            return View(bucket);
        }

        // GET: Buckets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Buckets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BucketName,Priority,Income,BucketCapacity,Expense")] Bucket bucket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bucket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bucket);
        }

        // GET: Buckets/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Bucket == null)
            {
                return NotFound();
            }

            var bucket = await _context.Bucket.FindAsync(id);
            if (bucket == null)
            {
                return NotFound();
            }
            return View(bucket);
        }

        // POST: Buckets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,BucketName,Priority,Income,BucketCapacity,Expense")] Bucket bucket)
        {
            if (id != bucket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bucket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BucketExists(bucket.Id))
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
            return View(bucket);
        }

        // GET: Buckets/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Bucket == null)
            {
                return NotFound();
            }

            var bucket = await _context.Bucket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bucket == null)
            {
                return NotFound();
            }

            return View(bucket);
        }

        // POST: Buckets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Bucket == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Bucket'  is null.");
            }
            var bucket = await _context.Bucket.FindAsync(id);
            if (bucket != null)
            {
                _context.Bucket.Remove(bucket);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BucketExists(string id)
        {
          return _context.Bucket.Any(e => e.Id == id);
        }
    }
}
