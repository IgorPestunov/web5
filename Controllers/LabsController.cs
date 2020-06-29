using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Backend5.Models;

namespace Backend5.Controllers
{
    public class LabsController : Controller
    {
        private readonly Context _context;

        public LabsController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Labs.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labs = await _context.Labs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (labs == null)
            {
                return NotFound();
            }

            return View(labs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Phones")] Labs labs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(labs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(labs);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labs = await _context.Labs.FindAsync(id);
            if (labs == null)
            {
                return NotFound();
            }
            return View(labs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Phones")] Labs labs)
        {
            if (id != labs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(labs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabsExists(labs.Id))
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
            return View(labs);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labs = await _context.Labs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (labs == null)
            {
                return NotFound();
            }

            return View(labs);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var labs = await _context.Labs.FindAsync(id);
            _context.Labs.Remove(labs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabsExists(int id)
        {
            return _context.Labs.Any(e => e.Id == id);
        }
    }
}
