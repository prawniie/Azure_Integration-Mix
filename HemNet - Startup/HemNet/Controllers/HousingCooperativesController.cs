using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HemNet.Data;
using HemNet.Models;

namespace HemNet.Controllers
{
    public class HousingCooperativesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HousingCooperativesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HousingCooperatives
        public async Task<IActionResult> Index()
        {
            return View(await _context.HousingCooperatives.ToListAsync());
        }

        // GET: HousingCooperatives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var housingCooperative = await _context.HousingCooperatives
                .FirstOrDefaultAsync(m => m.Id == id);
            if (housingCooperative == null)
            {
                return NotFound();
            }

            return View(housingCooperative);
        }

        // GET: HousingCooperatives/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HousingCooperatives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] HousingCooperative housingCooperative)
        {
            if (ModelState.IsValid)
            {
                _context.Add(housingCooperative);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(housingCooperative);
        }

        // GET: HousingCooperatives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var housingCooperative = await _context.HousingCooperatives.FindAsync(id);
            if (housingCooperative == null)
            {
                return NotFound();
            }
            return View(housingCooperative);
        }

        // POST: HousingCooperatives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] HousingCooperative housingCooperative)
        {
            if (id != housingCooperative.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(housingCooperative);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HousingCooperativeExists(housingCooperative.Id))
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
            return View(housingCooperative);
        }

        // GET: HousingCooperatives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var housingCooperative = await _context.HousingCooperatives
                .FirstOrDefaultAsync(m => m.Id == id);
            if (housingCooperative == null)
            {
                return NotFound();
            }

            return View(housingCooperative);
        }

        // POST: HousingCooperatives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var housingCooperative = await _context.HousingCooperatives.FindAsync(id);
            _context.HousingCooperatives.Remove(housingCooperative);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HousingCooperativeExists(int id)
        {
            return _context.HousingCooperatives.Any(e => e.Id == id);
        }
    }
}
