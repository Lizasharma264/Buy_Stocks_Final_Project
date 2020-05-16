using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Buy_Stocks_Final_Project.Models;
using Microsoft.AspNetCore.Authorization;

namespace Buy_Stocks_Final_Project.Controllers
{
    [Authorize(Roles = "stock_admin")]
    public class StocksBuyersController : Controller
    {
        private readonly Buy_Stocks_DBContext _context;

        public StocksBuyersController(Buy_Stocks_DBContext context)
        {
            _context = context;
        }

        // GET: StocksBuyers
        public async Task<IActionResult> Index()
        {
            return View(await _context.StocksBuyer.ToListAsync());
        }

        // GET: StocksBuyers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stocksBuyer = await _context.StocksBuyer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stocksBuyer == null)
            {
                return NotFound();
            }

            return View(stocksBuyer);
        }

        // GET: StocksBuyers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StocksBuyers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BuyerName,EmailAddress")] StocksBuyer stocksBuyer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stocksBuyer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stocksBuyer);
        }

        // GET: StocksBuyers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stocksBuyer = await _context.StocksBuyer.FindAsync(id);
            if (stocksBuyer == null)
            {
                return NotFound();
            }
            return View(stocksBuyer);
        }

        // POST: StocksBuyers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BuyerName,EmailAddress")] StocksBuyer stocksBuyer)
        {
            if (id != stocksBuyer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stocksBuyer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StocksBuyerExists(stocksBuyer.Id))
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
            return View(stocksBuyer);
        }

        // GET: StocksBuyers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stocksBuyer = await _context.StocksBuyer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stocksBuyer == null)
            {
                return NotFound();
            }

            return View(stocksBuyer);
        }

        // POST: StocksBuyers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stocksBuyer = await _context.StocksBuyer.FindAsync(id);
            _context.StocksBuyer.Remove(stocksBuyer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StocksBuyerExists(int id)
        {
            return _context.StocksBuyer.Any(e => e.Id == id);
        }
    }
}
