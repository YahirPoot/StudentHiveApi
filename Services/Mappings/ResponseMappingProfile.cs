using AutoMapper;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Entities;

namespace StudentHive.Services.Mappings;

public class ResponseMappingProfile : Profile 
{
    public ResponseMappingProfile() //this is how I want my entity to be transformed into a DTO
    {
        CreateMap<User,UserDTO>();

        CreateMap<TypeHouseRental, TypeHouseRentalDTO>();

        CreateMap<RentalHouseDetail, RentalHouseDetailDTO>();

        CreateMap<Location, LocationDTO>();

        CreateMap<HouseService, HouseServiceDTO>();

        CreateMap<RentalHouse,RentalHouseDTO>();
    }
}