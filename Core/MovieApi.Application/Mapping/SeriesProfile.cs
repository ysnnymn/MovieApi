using AutoMapper;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.SeriesCommands;
using MovieApi.Application.Features.MediatorDesignPattern.Results.SeriesResults;
using MovieApi.Domain.Entities;

namespace MovieApi.Application.Mapping
{
    public class SeriesProfile : Profile
    {public SeriesProfile()
        {
            CreateMap<CreateSeriesCommand, Series>().ReverseMap();
            CreateMap<UpdateSeriesCommand, Series>()
                .ForMember(dest => dest.SeriesId, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Series, GetSeriesQueryResult>();
            CreateMap<Series, GetSeriesByIdQueryResult>();
        }
    }
}