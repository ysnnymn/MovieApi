namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;

public class UpdateMovieCommand
{
    public int MovieId { get; set; }
    public string Title { get; set; }
    public string CoverImageUrl { get; set; }
    public decimal Raiting { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string CreatedYear { get; set; }
    public bool Status { get; set; }
}