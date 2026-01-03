namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.CastCommands;

public class RemoveCastCommand
{
    public RemoveCastCommand(int castId)
    {
        CastId = castId;
    }

    public int CastId { get; set; }
   
}