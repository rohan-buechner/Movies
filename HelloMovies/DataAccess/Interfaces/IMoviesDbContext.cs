using HelloMovies.Models;
using System.Data.Entity;

namespace HelloMovies.DataAccess.Interfaces
{
    public interface IMoviesDbContext
    {
        DbSet<Movie> Movies { get; }
        DbSet<GenreType> GenreTypes { get; }
    }
}
