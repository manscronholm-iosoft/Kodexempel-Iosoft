using Kodexempel.Application.Interfaces;
using Kodexempel.Domain;

namespace Kodexempel.Application;

public class MovieRentingService : IMovieRentingService
{
    /// ****
    /// Efter att vi har registrerat våra tjänster i DI-containern kan vi använda dem här i vår service och behöver inte sköta instansieringen själva.
    /// Så fort vi skapar en instans av denna service kommer DI-containern att skapa instanser av de klasser som denna service är beroende av.
    /// ****
    private readonly ICustomerRepository _customerRepository;
    private readonly IMovieRepository _movieRepository;
    
    public MovieRentingService(ICustomerRepository customerRepository, IMovieRepository movieRepository)
    {
        _customerRepository = customerRepository;
        _movieRepository = movieRepository;
    }
    
    public async Task<List<Movie>> GetMovies()
    {
        return await _movieRepository.GetMovies();
    }
    
    public async Task<List<Customer>> GetCustomers()
    {
        return await _customerRepository.GetCustomers();
    }
    
    public async Task RentMovie(Customer customer, Movie movie)
    {
        if(movie.RentedBy != null)
        {
            throw new Exception("Movie is already rented");
        }
        
        movie.RentedBy = customer;
        await _movieRepository.UpdateMovie(movie);
    }
    
    public async Task UnrentMovie(Movie movie)
    {
        movie.RentedBy = null;
        await _movieRepository.UpdateMovie(movie);
    }
}