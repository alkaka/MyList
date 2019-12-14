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
    public class CustomerlistsController : Controller
    {
        private readonly CustomerlistContext _context;

        public CustomerlistsController(CustomerlistContext context)
        {
            _context = context;
        }

        // GET: Customerlists
        public async Task<IActionResult> Index()
        {
            var customerlistContext = _context.Customerlist.Include(c => c.Countrylist);
            return View(await customerlistContext.ToListAsync());
        }


        // GET: Customerlists/Add
        public IActionResult Add()
        {
            ViewData["CountryListId"] = new SelectList(_context.Countrylist, "Id", "CountryName");
            return View();
        }

        // POST: Customerlists/Add
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Id,CustomerName,CountryListId")] Customerlist customerlist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerlist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryListId"] = new SelectList(_context.Countrylist, "Id", "CountryName", customerlist.CountryListId);
            return View(customerlist);
        }

        // GET: Customerlists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerlist = await _context.Customerlist.FindAsync(id);
            if (customerlist == null)
            {
                return NotFound();
            }
            ViewData["CountryListId"] = new SelectList(_context.Countrylist, "Id", "CountryName", customerlist.CountryListId);
            return View(customerlist);
        }

        // POST: Customerlists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerName,CountryListId")] Customerlist customerlist)
        {
            if (id != customerlist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerlist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerlistExists(customerlist.Id))
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
            ViewData["CountryListId"] = new SelectList(_context.Countrylist, "Id", "CountryName", customerlist.CountryListId);
            return View(customerlist);
        }



        // GET: Customerlist/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var customerlist = await _context.Customerlist.FindAsync(id);
            _context.Customerlist.Remove(customerlist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerlistExists(int id)
        {
            return _context.Customerlist.Any(e => e.Id == id);
        }
    }
}
