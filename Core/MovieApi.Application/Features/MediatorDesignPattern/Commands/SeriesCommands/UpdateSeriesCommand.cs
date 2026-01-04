using MediatR;
using MovieApi.Domain.Entities;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.SeriesCommands;

public class UpdateSeriesCommand:IRequest
{
    public int SeriesId { get; set; }
    public string Title { get; set; }
    public string CoverImageUrl { get; set; }
    public decimal Rating { get; set; }
    public string Description { get; set; }
    public DateTime FirstAirDate { get; set; }
    public int CreatedYear { get; set; }
    public int? AverageEpisodeDuration { get; set; }
    public int SeasonCount { get; set; }
    public int EpisodeCount { get; set; }
    public bool Status { get; set; }
    public int CategoryId { get; set; }

}