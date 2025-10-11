using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieServiceMock : IMovieService
    {
        public List<MovieCard> Get30HighestGrossingMovies()
        {
            var movies = new List<MovieCard>
            {
                new MovieCard { Title = "Forrest Gump", Id = 11 },
                new MovieCard { Title = "The Dark Knight", Id = 22 },
                new MovieCard { Title = "Interstellar", Id = 33 },
                new MovieCard { Title = "The Matrix", Id = 55 },
                new MovieCard { Title = "Fight Club", Id = 55 }
            };
            return movies;
        }
    }
}
