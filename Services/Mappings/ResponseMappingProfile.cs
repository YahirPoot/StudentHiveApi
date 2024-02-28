using System.Security.Cryptography;
using AutoMapper;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Dtos.AdminDtos;
using StudentHive.Domain.Entities;

namespace StudentHive.Services.Mappings;

public class ResponseMappingProfile : Profile 
{
    public ResponseMappingProfile() //this is how I want my entity to be transformed into a DTO
    {       //User => UserDTO
        CreateMap<User, UserDTO>();//*Validated
        CreateMap<RentalHouse, RentalHouseDTO>();//*Validated
        CreateMap<RentalHouseDetail, RentalHouseDetailDTO>();//*Validated
        CreateMap<HouseService, HouseServiceDTO>();//*Validated
        CreateMap<Location, HouseLocationDTO>();//*Validated

    }
}