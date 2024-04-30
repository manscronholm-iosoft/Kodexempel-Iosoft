using Kodexempel.Domain;

namespace Kodexempel.Application.Interfaces;

public interface IMovieRentingService
{
    Task<List<Movie>> GetMovies();
    Task<List<Customer>> GetCustomers();
    Task RentMovie(Customer customer, Movie movie);
    Task UnrentMovie(Movie movie);
}