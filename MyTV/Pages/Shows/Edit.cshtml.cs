using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyTV.Data;
using MyTV.Models;

namespace MyTV.Pages.Shows
{
    public class EditModel : PageModel
    {
        private readonly MyTV.Data.MyTVContext _context;

        public EditModel(MyTV.Data.MyTVContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Show Show { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Show == null)
            {
                return NotFound();
            }

            var show =  await _context.Show.FirstOrDefaultAsync(m => m.Id == id);
            if (show == null)
            {
                return NotFound();
            }
            Show = show;
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

            _context.Attach(Show).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowExists(Show.Id))
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

        private bool ShowExists(int id)
        {
          return _context.Show.Any(e => e.Id == id);
        }
    }
}
