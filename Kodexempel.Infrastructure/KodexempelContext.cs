using Kodexempel.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kodexempel.Infrastructure;

public class KodexempelContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Customer> Customers { get; set; }
    
    
    public KodexempelContext(DbContextOptions<KodexempelContext> options) : base(options)
    {
    }

}