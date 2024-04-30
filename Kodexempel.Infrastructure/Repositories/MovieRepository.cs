using Kodexempel.Application.Interfaces;
using Kodexempel.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kodexempel.Infrastructure.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly KodexempelContext _context;

    public MovieRepository(KodexempelContext context)
    {
        _context = context;
    }

    public async Task<List<Movie>> GetMovies()
    {
        return await _context.Movies.ToListAsync();
    }
    
    public async Task UpdateMovie(Movie movie)
    {
        _context.Movies.Update(movie);
        await _context.SaveChangesAsync();
    }
}