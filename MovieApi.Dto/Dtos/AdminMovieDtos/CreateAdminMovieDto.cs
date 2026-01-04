namespace MovieApi.Dto.Dtos.AdminMovieDtos;

public class CreateAdminMovieDto
{
    public string Title { get; set; }
    public string CoverImageUrl { get; set; }
    public Decimal Raitng { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public DateTime  RealeseDate { get; set; }
    public DateTime      CreatedYear { get; set; }
    public bool Status { get; set; }
    public int  CategoryId { get; set; }
    public string CategoryName { get; set; }
}