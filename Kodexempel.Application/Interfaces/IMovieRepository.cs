using Kodexempel.Domain;

namespace Kodexempel.Application.Interfaces;

public interface IMovieRepository
{
     Task<List<Movie>> GetMovies();
     Task UpdateMovie(Movie movie);
}