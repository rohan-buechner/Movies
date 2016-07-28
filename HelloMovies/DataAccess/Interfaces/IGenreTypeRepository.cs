using HelloMovies.DataAccess.Interfaces;
using HelloMovies.Models;

namespace HelloMovies.DataAccess.Infrastructure
{
    public interface IGenreTypeRepository : IGenericRepository<GenreType> 
	{
        GenreType GetSingle(int genreTypeId);
    } 	
}
