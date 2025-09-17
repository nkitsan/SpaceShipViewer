using AutoMapper;
using SpaceShipViewer.SpaceX.ApplicationCore.Entities;
using SpaceShipViewer.SpaceX.RestAPI.DTOs;

namespace SpaceShipViewer.SpaceX.RestAPI.Mappers
{
    public class RestApiProfile : Profile
    {
        public RestApiProfile()
        {
            CreateMap<Launch, LaunchDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Launch, LaunchDetailsDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.Details))
                .ForMember(dest => dest.DateUTC, opt => opt.MapFrom(src => src.DateUTC))
                .ForMember(dest => dest.FlightNumber, opt => opt.MapFrom(src => src.FlightNumber))
                .ForMember(dest => dest.Success, opt => opt.MapFrom(src => src.Success));
        }
    }
}
