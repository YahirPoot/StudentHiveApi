using AutoMapper;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Entities;

namespace StudentHive.Services.Mappings;

public class ResponseMappingProfile : Profile 
{
    public ResponseMappingProfile() //this is how I want my entity to be transformed into a DTO
    {       //User => UserDTO
        CreateMap<User,UserDTO>()
            .ForMember( dest => dest.IdUser, opt => opt.MapFrom( src => src.IdUser ));

        CreateMap<RentalHouse,RentalHouseDTO>(); 
        
        CreateMap<RentalHouseDetail, RentalHouseDetailDTO>(); 

        CreateMap<TypeHouseRental, TypeHouseRentalDTO>(); 

        CreateMap<HouseService, HouseServiceDTO>();

        CreateMap<HouseLocation, HouseLocationDTO>();
        

    }
}