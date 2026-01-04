using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.SeriesCommands;

public class RemoveSeriesCommand:IRequest
{
    public RemoveSeriesCommand(int seriesId)
    {
        SeriesId = seriesId;
    }

    public int SeriesId { get; set; }
   
}