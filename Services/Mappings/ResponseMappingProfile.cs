using AutoMapper;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Entities;

namespace StudentHive.Services.Mappings;

public class ResponseMappingProfile : Profile 
{
    public ResponseMappingProfile()
    {
        CreateMap<User,UserDTO>();

        CreateMap<RentalHouse,RentalHouseDTO>()
        .ForMember(
            dest => dest.PublicationDate,
            opt => opt.MapFrom( src => src.PublicationDate.DayOfWeek )
        );
    
    }
}