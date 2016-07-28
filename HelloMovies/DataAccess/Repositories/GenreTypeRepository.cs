using System.Linq;
using HelloMovies.Models;
using HelloMovies.DataAccess.Infrastructure;

namespace HelloMovies.DataAccess.Repositories
{
    public class GenreTypeRepository :
        GenericRepository<MoviesDbContext, GenreType>, IGenreTypeRepository
    {
        public GenreType GetSingle(int genreTypeId)
        {
            var query = GetAll().FirstOrDefault(x => x.Id == genreTypeId);
            return query;
        }
    }	
}
