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
    public class IndexModel : PageModel
    {
        private readonly MyTV.Data.MyTVContext _context;

        public IndexModel(MyTV.Data.MyTVContext context)
        {
            _context = context;
        }

        public IList<Show> Show { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Show != null)
            {
                Show = await _context.Show.ToListAsync();
            }
        }
    }
}
