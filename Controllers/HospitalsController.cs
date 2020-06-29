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
    public class HospitalsController : Controller
    {
        private readonly Context _context;

        public HospitalsController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Hospitals.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospitals = await _context.Hospitals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hospitals == null)
            {
                return NotFound();
            }

            return View(hospitals);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Phones")] Hospitals hospitals)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hospitals);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hospitals);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospitals = await _context.Hospitals.FindAsync(id);
            if (hospitals == null)
            {
                return NotFound();
            }
            return View(hospitals);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Phones")] Hospitals hospitals)
        {
            if (id != hospitals.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hospitals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HospitalsExists(hospitals.Id))
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
            return View(hospitals);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospitals = await _context.Hospitals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hospitals == null)
            {
                return NotFound();
            }

            return View(hospitals);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hospitals = await _context.Hospitals.FindAsync(id);
            _context.Hospitals.Remove(hospitals);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HospitalsExists(int id)
        {
            return _context.Hospitals.Any(e => e.Id == id);
        }
    }
}
