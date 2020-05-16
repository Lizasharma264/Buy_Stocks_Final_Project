using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Buy_Stocks_Final_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Buy_Stocks_Final_Project.Controllers
{
    public class StocksPaymentsController : Controller
    {
        private readonly Buy_Stocks_DBContext _context;

        private SignInManager<IdentityUser> SignInManager;


        private UserManager<IdentityUser> UserManager;


        public StocksPaymentsController(Buy_Stocks_DBContext context,
             SignInManager<IdentityUser> _SignInManager,


         UserManager<IdentityUser> _UserManager

            
            
            )
        {

            SignInManager = _SignInManager;
            UserManager = _UserManager;
            _context = context;
        }

        // GET: StocksPayments
        [Authorize(Roles = "stock_admin")]
        public async Task<IActionResult> Index()
        {
            var buy_Stocks_DBContext = _context.StocksPayment.Include(s => s.Company).Include(s => s.StocksBuyer);
            return View(await buy_Stocks_DBContext.ToListAsync());
        }

        // GET: StocksPayments/Details/5
        [Authorize(Roles = "stock_admin, stocks_buyer")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stocksPayment = await _context.StocksPayment
                .Include(s => s.Company)
                .Include(s => s.StocksBuyer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stocksPayment == null)
            {
                return NotFound();
            }

            return View(stocksPayment);
        }

        // GET: StocksPayments/Create
        [Authorize(Roles = "stocks_buyer")]
        public IActionResult Create(int Id)
        {
            if (SignInManager.IsSignedIn(User)) {

                var buyer = (from stockBuyer in _context.StocksBuyer
                             where stockBuyer.EmailAddress.Equals(User.Identity.Name)
                             select stockBuyer).FirstOrDefault();

                var company = (from companies in _context.Company
                             where companies.Id == Id
                             select companies).FirstOrDefault();

                StocksPayment payment = new StocksPayment();
                payment.CompanyId = Id;
                payment.StocksBuyerId = buyer.Id;
                payment.Company = company;
                payment.StocksBuyer = buyer;

                return View(payment);
            
            }


         
            return View();
        }

        // POST: StocksPayments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "stocks_buyer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyId,StocksBuyerId,NumberOfStocks")] StocksPayment stocksPayment)
        {
            if (ModelState.IsValid)
            {

                var company = (from companies in _context.Company
                               where companies.Id == stocksPayment.CompanyId
                               select companies).FirstOrDefault();

                company.StocksSold = company.StocksSold + stocksPayment.NumberOfStocks;
                stocksPayment.Id = 0;
                _context.StocksPayment.Add(stocksPayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details),new { id = stocksPayment.Id });
            }
        
            return View(stocksPayment);
        }

        // GET: StocksPayments/Edit/5
        [Authorize(Roles = "stock_admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stocksPayment = await _context.StocksPayment.FindAsync(id);
            if (stocksPayment == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Id", stocksPayment.CompanyId);
            ViewData["StocksBuyerId"] = new SelectList(_context.StocksBuyer, "Id", "Id", stocksPayment.StocksBuyerId);
            return View(stocksPayment);
        }

        // POST: StocksPayments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "stock_admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyId,StocksBuyerId,NumberOfStocks")] StocksPayment stocksPayment)
        {
            if (id != stocksPayment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stocksPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StocksPaymentExists(stocksPayment.Id))
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
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Id", stocksPayment.CompanyId);
            ViewData["StocksBuyerId"] = new SelectList(_context.StocksBuyer, "Id", "Id", stocksPayment.StocksBuyerId);
            return View(stocksPayment);
        }

        // GET: StocksPayments/Delete/5
        [Authorize(Roles = "stock_admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            

           

            var stocksPayment = await _context.StocksPayment
                .Include(s => s.Company)
                .Include(s => s.StocksBuyer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stocksPayment == null)
            {
                return NotFound();
            }

            return View(stocksPayment);
        }

        // POST: StocksPayments/Delete/5
        [Authorize(Roles = "stock_admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stocksPayment = await _context.StocksPayment
                .Include(s => s.Company)
                .Include(s => s.StocksBuyer)
                .FirstOrDefaultAsync(m => m.Id == id);
           
            stocksPayment.Company.StocksSold = stocksPayment.Company.StocksSold - stocksPayment.NumberOfStocks;
            if (stocksPayment.Company.StocksSold < 0) {
                stocksPayment.Company.StocksSold = 0;
            }
            _context.StocksPayment.Remove(stocksPayment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StocksPaymentExists(int id)
        {
            return _context.StocksPayment.Any(e => e.Id == id);
        }
    }
}
