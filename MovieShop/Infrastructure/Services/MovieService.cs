using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        public List<MovieCard> Get30HighestGrossingMovies()
        {
            var movies = new List<MovieCard>
            {
                new MovieCard { Title = "Forrest Gump", Id = 1, PosterUrl = "https://image.tmdb.org/t/p/w342/saHP97rTPS5eLmrLQEcANmKrsFl.jpg" },
                new MovieCard { Title = "The Dark Knight", Id = 2, PosterUrl = "https://image.tmdb.org/t/p/w342/qJ2tW6WMUDux911r6m7haRef0WH.jpg" },
                new MovieCard { Title = "Interstellar", Id = 3, PosterUrl = "https://image.tmdb.org/t/p/w342/rAiYTfKGqDCRIIqo664sY9XZIvQ.jpg" },
                new MovieCard { Title = "The Matrix", Id = 4, PosterUrl = "https://image.tmdb.org/t/p/w342/f89U3ADr1oiB1s9GkdPOEpXUk5H.jpg" },
                new MovieCard { Title = "Fight Club", Id = 5, PosterUrl = "https://image.tmdb.org/t/p/w342/bptfVGEQuv6vDTIMVCHjJ9Dz8PX.jpg" }
            };
            return movies;
        }
    }
}
