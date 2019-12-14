using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyList.Data;
using MyList.Models;

namespace MyList.Controllers
{
    public class CountrylistsController : Controller
    {
        private readonly CustomerlistContext _context;

        public CountrylistsController(CustomerlistContext context)
        {
            _context = context;
        }

        // GET: Countrylists
        public async Task<IActionResult> Index()
        {
            return View(await _context.Countrylist.ToListAsync());
        }

        // GET: Countrylists/Add
        public IActionResult Add()
        {
            return View();
        }

        // POST: Countrylists/Add
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Id,CountryName")] Countrylist countrylist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(countrylist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(countrylist);
        }

        // GET: Countrylists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countrylist = await _context.Countrylist.FindAsync(id);
            if (countrylist == null)
            {
                return NotFound();
            }
            return View(countrylist);
        }

        // POST: Countrylists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CountryName")] Countrylist countrylist)
        {
            if (id != countrylist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(countrylist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountrylistExists(countrylist.Id))
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
            return View(countrylist);
        }


        // GET: Countrylist/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var cuntrylist = await _context.Countrylist.FindAsync(id);
            _context.Countrylist.Remove(cuntrylist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool CountrylistExists(int id)
        {
            return _context.Countrylist.Any(e => e.Id == id);
        }
    }
}
