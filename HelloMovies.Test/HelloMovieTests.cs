using HelloMovies.Controllers;
using HelloMovies.DataAccess.Infrastructure;
using HelloMovies.Models;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace HelloMovies.Test
{
    //[TestFixture]
    public class HelloMovieTests
    {
        private IMovieRepository mockRepo;
        private List<Movie> mockData;
        private MoviesController controller;

        [SetUp]
        public void Init()
        {
            mockRepo = MockRepository.GenerateMock<IMovieRepository>();

            mockData = new List<Movie>() {
                new Movie {
                    Id = 1,
                    Title = "Title",
                    Released = new DateTime(2001, 1, 1),
                    GenreTypeId = 1,
                    Genre = new GenreType { Id = 1, Type = "Type" }
                },
              new Movie {
                    Id = 2,
                    Title = "Title 2",
                    Released = new DateTime(2002, 2, 2),
                    GenreTypeId = 2,
                    Genre = new GenreType { Id = 2, Type = "Type 2" }
                }};

            controller = new MoviesController(mockRepo);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
        }

        [TestCase]
        public void AllMoviesShouldReturnAllMovies()
        {
            // Arrange
            mockRepo.Stub(dao => dao.GetAll()).Return(mockData.AsQueryable());            

            // Act
            var response = controller.GetMovies();

            // Assert
            Assert.IsTrue(response.ToList().Count() == 2);
        }

        [TestCase]
        public void GetMovieSouldReturnASpecificMovie()
        {
            // Arrange
            mockRepo.Stub(dao => dao.GetSingle(1)).Return(mockData.Where(o => o.Id == 1).Single());

            // Act
            var response = controller.GetMovie(1) as OkNegotiatedContentResult<Movie>;

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.Content.Id);
        }

        [TestCase]
        public void PostMovieShouldRejectGenreType1WithTitlesThatsExceed15()
        {
            // Arrange
            var longTitleMovie = new Movie { GenreTypeId = 1, Title = "This title is longer then 15 characters", Released = new DateTime(2015,1,1) }; 
            var stub = mockRepo.Stub(dao => dao.Add(longTitleMovie)).Throw(new ArgumentException());

            // Act & Assert
            Assert.Throws<HttpResponseException>(() => controller.PostMovie(longTitleMovie));           
        }

        [TestCase]
        public void PostMovieShouldSaveValidMovies()
        {
            // Arrange
            var validMovie = new Movie { GenreTypeId = 2, Title = "Valid", Released = new DateTime(2015, 1, 1) };

            // Act
            IHttpActionResult actionResult = controller.PostMovie(validMovie);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Movie>;

            // Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(0, createdResult.RouteValues["id"]);
        }
    }

}
