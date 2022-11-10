using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyTV.Data;
using MyTV.Models;

namespace MyTV.Pages.Shows
{
    public class DeleteModel : PageModel
    {
        private readonly MyTV.Data.MyTVContext _context;

        public DeleteModel(MyTV.Data.MyTVContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Show Show { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Show == null)
            {
                return NotFound();
            }

            var show = await _context.Show.FirstOrDefaultAsync(m => m.Id == id);

            if (show == null)
            {
                return NotFound();
            }
            else 
            {
                Show = show;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Show == null)
            {
                return NotFound();
            }
            var show = await _context.Show.FindAsync(id);

            if (show != null)
            {
                Show = show;
                _context.Show.Remove(Show);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
