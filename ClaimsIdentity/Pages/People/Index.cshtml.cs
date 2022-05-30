using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClaimsIdentity.Data;
using ClaimsIdentity.Models;

namespace ClaimsIdentity.Pages.People
{
    public class IndexModel : PageModel
    {
        private readonly ClaimsIdentity.Data.PeopleContext _context;

        public IndexModel(ClaimsIdentity.Data.PeopleContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.User != null)
            {
                User = await _context.User.ToListAsync();
            }
        }
    }
}
