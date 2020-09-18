using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SweetAlertConfirmationAspCore.Models;
using SweetAlertConfirmationAspCore.data;

namespace SweetAlertConfirmationAspCore.Controllers
{
    public class ProvinsisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProvinsisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Provinsis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Provinsis.ToListAsync());
        }

        // GET: Provinsis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provinsi = await _context.Provinsis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (provinsi == null)
            {
                return NotFound();
            }

            return View(provinsi);
        }

        // GET: Provinsis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Provinsis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nama")] Provinsi provinsi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(provinsi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(provinsi);
        }

        // GET: Provinsis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provinsi = await _context.Provinsis.FindAsync(id);
            if (provinsi == null)
            {
                return NotFound();
            }
            return View(provinsi);
        }

        // POST: Provinsis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nama")] Provinsi provinsi)
        {
            if (id != provinsi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(provinsi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProvinsiExists(provinsi.Id))
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
            return View(provinsi);
        }

        // GET: Provinsis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provinsi = await _context.Provinsis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (provinsi == null)
            {
                return NotFound();
            }

            return View(provinsi);
        }

        // POST: Provinsis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var provinsi = await _context.Provinsis.FindAsync(id);
            _context.Provinsis.Remove(provinsi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProvinsiExists(int id)
        {
            return _context.Provinsis.Any(e => e.Id == id);
        }
    }
}
