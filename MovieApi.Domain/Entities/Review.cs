namespace MovieApi.Domain.Entities;

public class Review
{
    public int ReviewId { get; set; }
    public string ReviewComment { get; set; }
    public int UserRaiting { get; set; }
    public DateTime ReviewDate { get; set; }
    public bool Status { get; set; }
}