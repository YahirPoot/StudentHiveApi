using AutoMapper;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Entities;

namespace StudentHive.Services.Mappings;

public class ResponseMappingProfile : Profile 
{
    public ResponseMappingProfile() //this is how I want my entity to be transformed into a DTO
    {
        CreateMap<User,UserDTO>(); //*Validated

        CreateMap<RentalHouse,RentalHouseDTO>(); //*Validate
        
        CreateMap<RentalHouseDetail, RentalHouseDetailDTO>(); //*Validated

        CreateMap<TypeHouseRental, TypeHouseRentalDTO>(); //*Validated

        CreateMap<HouseService, HouseServiceDTO>();//*Validated

        CreateMap<HouseLocation, HouseLocationDTO>();//*

        

    }
}