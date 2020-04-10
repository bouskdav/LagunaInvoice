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
    public class IssuedInvoicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IssuedInvoicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IssuedInvoices
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.IssuedInvoices.Include(i => i.R_Contact);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: IssuedInvoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issuedInvoice = await _context.IssuedInvoices
                .Include(i => i.R_Contact)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (issuedInvoice == null)
            {
                return NotFound();
            }

            return View(issuedInvoice);
        }

        // GET: IssuedInvoices/Create
        public IActionResult Create()
        {
            ViewData["ContactID"] = new SelectList(_context.Contacts, "ID", "ID");
            return View();
        }

        // POST: IssuedInvoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ContactID,DateCreated,DateIssued,DateDue,DateVAT,NotePublic,NoteInternal,Footer")] IssuedInvoice issuedInvoice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(issuedInvoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContactID"] = new SelectList(_context.Contacts, "ID", "ID", issuedInvoice.ContactID);
            return View(issuedInvoice);
        }

        // GET: IssuedInvoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issuedInvoice = await _context.IssuedInvoices.FindAsync(id);
            if (issuedInvoice == null)
            {
                return NotFound();
            }
            ViewData["ContactID"] = new SelectList(_context.Contacts, "ID", "ID", issuedInvoice.ContactID);
            return View(issuedInvoice);
        }

        // POST: IssuedInvoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ContactID,DateCreated,DateIssued,DateDue,DateVAT,NotePublic,NoteInternal,Footer")] IssuedInvoice issuedInvoice)
        {
            if (id != issuedInvoice.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(issuedInvoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IssuedInvoiceExists(issuedInvoice.ID))
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
            ViewData["ContactID"] = new SelectList(_context.Contacts, "ID", "ID", issuedInvoice.ContactID);
            return View(issuedInvoice);
        }

        // GET: IssuedInvoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issuedInvoice = await _context.IssuedInvoices
                .Include(i => i.R_Contact)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (issuedInvoice == null)
            {
                return NotFound();
            }

            return View(issuedInvoice);
        }

        // POST: IssuedInvoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var issuedInvoice = await _context.IssuedInvoices.FindAsync(id);
            _context.IssuedInvoices.Remove(issuedInvoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IssuedInvoiceExists(int id)
        {
            return _context.IssuedInvoices.Any(e => e.ID == id);
        }
    }
}
