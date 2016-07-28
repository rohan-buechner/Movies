using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HelloMovies.Models;
using HelloMovies.DataAccess.Infrastructure;

namespace HelloMovies.Controllers
{
    public class MoviesController : ApiController
    {
        private readonly IMovieRepository _Repo;

        public MoviesController(IMovieRepository Repo)
        {
            _Repo = Repo;
        }
        
        // GET: api/Movies
        public IQueryable<Movie> GetMovies()
        {
            return _Repo.GetAll().Include(o => o.Genre);
        }

        // GET: api/Movies/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult GetMovie(int id)
        {
            Movie movie = _Repo.GetSingle(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }
        
        // POST: api/Movies
        [ResponseType(typeof(Movie))]
        public IHttpActionResult PostMovie(Movie movie)
        {     
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _Repo.Add(movie);
                _Repo.Save();
            }
            catch (ArgumentException ae)
            {
                // return a custom server side validation message to the user
                // can alse be handled using an attribute once solution grows
                // plus would be more effiecient as opposed to throwing an exception
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                   ReasonPhrase = ae.Message
                };
                throw new HttpResponseException(resp);
            }

            return CreatedAtRoute("DefaultApi", new { id = movie.Id }, movie);
        }       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _Repo.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovieExists(int id)
        {
            return _Repo.FindBy(e => e.Id == id).Count() > 0;
        }      
    }
}