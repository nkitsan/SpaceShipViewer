using AutoMapper;
using Oddity.Models.Launches;
using SpaceShipViewer.SpaceX.ApplicationCore.Entities;

namespace SpaceShipViewer.SpaceX.Workers.Mappers
{
    public class WorkerServicesProfile : Profile
    {
        public WorkerServicesProfile()
        {
            CreateMap<LaunchInfo, Launch>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.Details ?? string.Empty))
                .ForMember(dest => dest.DateUTC, opt => opt.MapFrom(src => src.DateUtc))
                .ForMember(dest => dest.FlightNumber, opt => opt.MapFrom(src => src.FlightNumber))
                .ForMember(dest => dest.Success, opt => opt.MapFrom(src => src.Success));
        }
    }
}
