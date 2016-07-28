using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using HelloMovies.Models;
using HelloMovies.DataAccess.Infrastructure;

namespace HelloMovies.WebApi
{
    public class GenreTypesController : ApiController
    {
        private readonly IGenreTypeRepository _Repo;

        public GenreTypesController(IGenreTypeRepository Repo)
        {
            _Repo = Repo;
        }

        // GET: api/GenreTypes
        public IQueryable<GenreType> GetGenreTypes()
        {
            return _Repo.GetAll();
        }

        // GET: api/GenreTypes/5
        [ResponseType(typeof(GenreType))]
        public IHttpActionResult GetGenreType(int id)
        {
            GenreType genreType = _Repo.GetSingle(id);

            if (genreType == null)
            {
                return NotFound();
            }

            return Ok(genreType);
        }        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _Repo.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GenreTypeExists(int id)
        {
            return _Repo.FindBy(e => e.Id == id).Count() > 0;
        }
    }
}