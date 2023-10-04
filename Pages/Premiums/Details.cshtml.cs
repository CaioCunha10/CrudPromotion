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
    public class DetailsModel : PageModel
    {
        private readonly CrudSundayTst.Data.ApplicationDbContext _context;

        public DetailsModel(CrudSundayTst.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
