using HelloMovies.DataAccess.Interfaces;
using System.Data.Entity;

namespace HelloMovies.Models
{
    public class MoviesDbContext : DbContext, IMoviesDbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MoviesDbContext() : base("name=MoviesDbContext")
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<GenreType> GenreTypes { get; set; }
    }
}
