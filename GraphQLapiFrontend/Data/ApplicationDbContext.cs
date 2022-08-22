using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GraphQLapiFrontend.Models;

namespace GraphQLapiFrontend.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<GraphQLapiFrontend.Models.Author>? Author { get; set; }
        public DbSet<GraphQLapiFrontend.Models.Book>? Book { get; set; }
    }
}