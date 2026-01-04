namespace MovieApi.Domain.Entities;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public bool Status { get; set; }
    public string? Descripiton { get; set; }
    public List<Movie> Movies { get; set; }
    public List<Series> Series { get; set; }
    
}