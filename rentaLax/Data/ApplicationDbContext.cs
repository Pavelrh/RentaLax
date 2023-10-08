using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using rentaLax.Models;

namespace rentaLax.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<rentaLax.Models.Item> Items { get; set; } = default!;
        public DbSet<ItemType> ItemTypes { get; set; }
    }
}