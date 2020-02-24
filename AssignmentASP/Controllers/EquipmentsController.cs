using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment1_200425207.Models;
using AssignmentASP.Data;

namespace AssignmentASP.Controllers
{
    public class EquipmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EquipmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Equipments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Equipments.ToListAsync());
        }

        // GET: Equipments/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipments = await _context.Equipments
                .FirstOrDefaultAsync(m => m.EquipmentID == id);
            if (equipments == null)
            {
                return NotFound();
            }

            return View(equipments);
        }

        // GET: Equipments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Equipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EquipmentID,Model,Size,Price,ProductID")] Equipments equipments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipments);
        }

        // GET: Equipments/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipments = await _context.Equipments.FindAsync(id);
            if (equipments == null)
            {
                return NotFound();
            }
            return View(equipments);
        }

        // POST: Equipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EquipmentID,Model,Size,Price,ProductID")] Equipments equipments)
        {
            if (id != equipments.EquipmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentsExists(equipments.EquipmentID))
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
            return View(equipments);
        }

        // GET: Equipments/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipments = await _context.Equipments
                .FirstOrDefaultAsync(m => m.EquipmentID == id);
            if (equipments == null)
            {
                return NotFound();
            }

            return View(equipments);
        }

        // POST: Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var equipments = await _context.Equipments.FindAsync(id);
            _context.Equipments.Remove(equipments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipmentsExists(string id)
        {
            return _context.Equipments.Any(e => e.EquipmentID == id);
        }
    }
}
