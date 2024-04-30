namespace Kodexempel.Domain;

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    
    public virtual ICollection<Movie> RentedMovies { get; set; }
}