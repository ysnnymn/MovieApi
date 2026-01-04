namespace MovieApi.Dto.Dtos.MovieDtos;

public class ResultMovieDto
{
    public int MovieId { get; set; }
    public string Title { get; set; }
    public string CoverImageUrl { get; set; }
    public Decimal Raitng { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public DateTime  RealeseDate { get; set; }
    public string      CreatedYear { get; set; }
    public bool Status { get; set; }
}