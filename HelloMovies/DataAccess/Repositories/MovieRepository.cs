using System.Linq;
using HelloMovies.Models;
using HelloMovies.DataAccess.Infrastructure;
using HelloMovies.DataAccess.Interfaces;

namespace HelloMovies.DataAccess.Repositories
{
    public class MovieRepository :
        GenericRepository<MoviesDbContext, Movie>, IMovieRepository
    {
        public Movie GetSingle(int movieId)
        {
            var query = GetAll().FirstOrDefault(x => x.Id == movieId);
            return query;
        }

        public override string ValidationAdd(Movie entity)
        {
            // just an example of more centralized "complex" validations.
            // eg. the model will reject items that dont fulfill its base requirements, but does not easilt support conditional validations
            if (entity.GenreTypeId == 1 && entity.Title.Length > 15)
            {
                return "Title is too long for this genre!";
            }

            return string.Empty;
        }
    }	
}
