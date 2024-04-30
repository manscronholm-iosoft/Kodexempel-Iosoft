namespace Kodexempel.Domain;

public class Movie
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Director { get; set; }
    public int ReleaseYear { get; set; }
    public string Genre { get; set; }
    
    public virtual Customer? RentedBy { get; set; }
}