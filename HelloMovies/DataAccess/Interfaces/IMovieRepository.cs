using HelloMovies.DataAccess.Interfaces;
using HelloMovies.Models;

namespace HelloMovies.DataAccess.Infrastructure
{
    public interface IMovieRepository : IGenericRepository<Movie> 
	{
       Movie GetSingle(int movieid);
    } 	
}
