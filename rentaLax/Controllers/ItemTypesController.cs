﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using rentaLax.Data;
using rentaLax.Models;

namespace rentaLax.Controllers
{
    [Authorize]
    public class ItemTypesController : Controller
    {
        
        private readonly ApplicationDbContext _context;

       
        public ItemTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ItemTypes
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
              return _context.ItemTypes != null ? 
                          View(await _context.ItemTypes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ItemTypes'  is null.");
        }

        // GET: ItemTypes/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ItemTypes == null)
            {
                return NotFound();
            }

            var itemType = await _context.ItemTypes
                .FirstOrDefaultAsync(m => m.ItemTypeId == id);
            if (itemType == null)
            {
                return NotFound();
            }

            return View(itemType);
        }

        // GET: ItemTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemTypeId,Name,PriceType,Abbreviation")] ItemType itemType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemType);
        }

        // GET: ItemTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ItemTypes == null)
            {
                return NotFound();
            }

            var itemType = await _context.ItemTypes.FindAsync(id);
            if (itemType == null)
            {
                return NotFound();
            }
            return View(itemType);
        }

        // POST: ItemTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemTypeId,Name,PriceType,Abbreviation")] ItemType itemType)
        {
            if (id != itemType.ItemTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemTypeExists(itemType.ItemTypeId))
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
            return View(itemType);
        }

        // GET: ItemTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ItemTypes == null)
            {
                return View("Error"); //NotFound();
            }

            var itemType = await _context.ItemTypes
                .FirstOrDefaultAsync(m => m.ItemTypeId == id);
            if (itemType == null)
            {
                return View("Error");
            }

            return View("Delete", itemType);
        }

        // POST: ItemTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ItemTypes == null)
            {
                return View("Error");//Problem("Entity set 'ApplicationDbContext.ItemTypes'  is null.");
            }
            var itemType = await _context.ItemTypes.FindAsync(id);
            if (itemType != null)
            {
                _context.ItemTypes.Remove(itemType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemTypeExists(int id)
        {
          return (_context.ItemTypes?.Any(e => e.ItemTypeId == id)).GetValueOrDefault();
        }
    }
}
