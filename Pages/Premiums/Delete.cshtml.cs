using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CrudSundayTst.Data;
using CrudSundayTst.Models;

namespace CrudSundayTst.Pages_Premiums
{
    public class DeleteModel : PageModel
    {
        private readonly CrudSundayTst.Data.ApplicationDbContext _context;

        public DeleteModel(CrudSundayTst.Data.ApplicationDbContext context)
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

            var premium = await _context.Premium.FirstOrDefaultAsync(m => m.Id == id);

            if (premium == null)
            {
                return NotFound();
            }
            else 
            {
                Premium = premium;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Premium == null)
            {
                return NotFound();
            }
            var premium = await _context.Premium.FindAsync(id);

            if (premium != null)
            {
                Premium = premium;
                _context.Premium.Remove(Premium);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
