namespace MovieApi.Application.Features.CQRSDesignPattern.Queries.CastQueries;

public class GetCastByIdQuery
{
    public GetCastByIdQuery(int castId)
    {
        CastId = castId;
    }

    public int CastId { get; set; }
   
}