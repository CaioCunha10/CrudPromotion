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
    public class IndexModel : PageModel
    {
        private readonly CrudSundayTst.Data.ApplicationDbContext _context;

        public IndexModel(CrudSundayTst.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Premium> Premium { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Premium != null)
            {
                Premium = await _context.Premium
                .Include(p => p.Student).ToListAsync();
            }
        }
    }
}
