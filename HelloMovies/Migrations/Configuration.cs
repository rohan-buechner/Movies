namespace HelloMovies.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using HelloMovies.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MoviesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HelloMovies.Models.MoviesDbContext";
        }

        protected override void Seed(MoviesDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.GenreTypes.AddOrUpdate(
                o => o.Type,
                new GenreType { Type = "Comedy" },
                new GenreType { Type = "Indie" },
                new GenreType { Type = "Action" },
                new GenreType { Type = "Sci-Fi" },
                new GenreType { Type = "Thriller" });

            context.SaveChanges();

            // get genre type id's
            var genres = context.GenreTypes.ToDictionary(o => o.Type, o => o.Id);

            context.Movies.AddOrUpdate(
                o => o.Title,
                new Movie { Title = "Pineapple Express", Released = new DateTime(2008, 8, 6), GenreTypeId = genres["Comedy"] },
                new Movie { Title = "Enter The Ninja", Released = new DateTime(1981, 10, 2), GenreTypeId = genres["Action"] },
                new Movie { Title = "Scott Pilgim vs. the World", Released = new DateTime(2010, 08, 13), GenreTypeId = genres["Indie"] },
                new Movie { Title = "Star Wars IV - A New Hope", Released = new DateTime(1977, 05, 25), GenreTypeId = genres["Sci-Fi"] },
                new Movie { Title = "Machete", Released = new DateTime(2010, 09, 01), GenreTypeId = genres["Action"] },
                new Movie { Title = "Sin City", Released = new DateTime(2005, 04, 01), GenreTypeId = genres["Thriller"] });

            context.SaveChanges();

        }
    }
}
