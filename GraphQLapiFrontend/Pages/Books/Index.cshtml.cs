using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GraphQLapiFrontend.Data;
using GraphQLapiFrontend.Models;

namespace GraphQLapiFrontend.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly GraphQLapiFrontend.Data.ApplicationDbContext _context;

        public IndexModel(GraphQLapiFrontend.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Book != null)
            {
                Book = await _context.Book
                .Include(b => b.Author).ToListAsync();
            }
        }
    }
}
