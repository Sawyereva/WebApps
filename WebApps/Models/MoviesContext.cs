using Microsoft.EntityFrameworkCore;

namespace WebApps.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options): base (options) //Constructor
        { 
        }

        public DbSet<Movie> Movies { get; set;}
    }
}
