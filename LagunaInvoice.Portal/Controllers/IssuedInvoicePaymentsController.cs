using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LagunaInvoice.Portal.Data;
using LagunaInvoice.Portal.Data.Entities;

namespace LagunaInvoice.Portal.Controllers
{
    public class IssuedInvoicePaymentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IssuedInvoicePaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IssuedInvoicePayments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.IssuedInvoicePayments.Include(i => i.R_Invoice);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: IssuedInvoicePayments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issuedInvoicePayment = await _context.IssuedInvoicePayments
                .Include(i => i.R_Invoice)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (issuedInvoicePayment == null)
            {
                return NotFound();
            }

            return View(issuedInvoicePayment);
        }

        // GET: IssuedInvoicePayments/Create
        public IActionResult Create()
        {
            ViewData["IssuedInvoiceID"] = new SelectList(_context.IssuedInvoices, "ID", "ID");
            return View();
        }

        // POST: IssuedInvoicePayments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IssuedInvoiceID,PaymentDate,Note,Amount")] IssuedInvoicePayment issuedInvoicePayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(issuedInvoicePayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IssuedInvoiceID"] = new SelectList(_context.IssuedInvoices, "ID", "ID", issuedInvoicePayment.IssuedInvoiceID);
            return View(issuedInvoicePayment);
        }

        // GET: IssuedInvoicePayments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issuedInvoicePayment = await _context.IssuedInvoicePayments.FindAsync(id);
            if (issuedInvoicePayment == null)
            {
                return NotFound();
            }
            ViewData["IssuedInvoiceID"] = new SelectList(_context.IssuedInvoices, "ID", "ID", issuedInvoicePayment.IssuedInvoiceID);
            return View(issuedInvoicePayment);
        }

        // POST: IssuedInvoicePayments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IssuedInvoiceID,PaymentDate,Note,Amount")] IssuedInvoicePayment issuedInvoicePayment)
        {
            if (id != issuedInvoicePayment.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(issuedInvoicePayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IssuedInvoicePaymentExists(issuedInvoicePayment.ID))
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
            ViewData["IssuedInvoiceID"] = new SelectList(_context.IssuedInvoices, "ID", "ID", issuedInvoicePayment.IssuedInvoiceID);
            return View(issuedInvoicePayment);
        }

        // GET: IssuedInvoicePayments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issuedInvoicePayment = await _context.IssuedInvoicePayments
                .Include(i => i.R_Invoice)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (issuedInvoicePayment == null)
            {
                return NotFound();
            }

            return View(issuedInvoicePayment);
        }

        // POST: IssuedInvoicePayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var issuedInvoicePayment = await _context.IssuedInvoicePayments.FindAsync(id);
            _context.IssuedInvoicePayments.Remove(issuedInvoicePayment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IssuedInvoicePaymentExists(int id)
        {
            return _context.IssuedInvoicePayments.Any(e => e.ID == id);
        }
    }
}
