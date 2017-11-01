using Microsoft.EntityFrameworkCore;

namespace Restauranter.Models
{
    public class RestContext : DbContext
    {
        public RestContext(DbContextOptions<RestContext> options) : base(options) { }
        public DbSet<Review> reviews {get; set;}
    }
}