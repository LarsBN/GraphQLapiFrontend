using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GraphQLapiFrontend.Data;
using GraphQLapiFrontend.Models;

namespace GraphQLapiFrontend.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly GraphQLapiFrontend.Data.ApplicationDbContext _context;

        public IndexModel(GraphQLapiFrontend.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Author> Author { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Author != null)
            {
                Author = (IList<Author>)await _context.Author.TemporalAll().OrderByDescending(author => EF.Property<DateTime> (author, "PeriodStart")).Select(Author => new { Author = Author, PeriodStart = EF.Property <DateTime> (Author, "PeriodStart"), PeriodEnd = EF.Property<DateTime>(Author, "PeriodEnd")}).ToListAsync();
            }
        }
    }
}
