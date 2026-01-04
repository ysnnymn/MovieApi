namespace MovieApi.Domain.Entities;

public class ReletedMovie
{
    public int ReletedMovieId { get; set; }
    public int  MovieId { get; set; }
    public int UserId { get; set; }
    public bool IsWatch { get; set; }
    
    
}