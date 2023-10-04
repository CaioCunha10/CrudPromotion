using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudSundayTst.Data;
using CrudSundayTst.Models;

namespace CrudSundayTst.Pages_Premiums
{
    public class EditModel : PageModel
    {
        private readonly CrudSundayTst.Data.ApplicationDbContext _context;

        public EditModel(CrudSundayTst.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Premium Premium { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Premium == null)
            {
                return NotFound();
            }

            var premium =  await _context.Premium.FirstOrDefaultAsync(m => m.Id == id);
            if (premium == null)
            {
                return NotFound();
            }
            Premium = premium;
           ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Premium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PremiumExists(Premium.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PremiumExists(int id)
        {
          return (_context.Premium?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
