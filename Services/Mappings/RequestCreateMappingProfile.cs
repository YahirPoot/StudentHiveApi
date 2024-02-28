using AutoMapper;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Dtos.AdminDtos;
using StudentHive.Domain.Entities;

namespace StudentHive.Services.Mappings;

public class RequestCreateMappingProfile : Profile
{
    public RequestCreateMappingProfile()
    {               //src                   dest
        CreateMap<RentalHouseCreateDTO, RentalHouse>()             //*Validated
        .AfterMap
        (
            (src, dest) => 
                {
                    dest.PublicationDate = DateTime.Now;
                }
        );//UserCreateDTO => User
        CreateMap<UserCreateDTO, User>();//*Validated
        CreateMap<RentalHouseDetailDTO, RentalHouseDetail>();//*Validated
        CreateMap<HouseServiceDTO,HouseService >();//*Validated
        CreateMap<HouseLocationDTO,Location >();//*
        
    }
}
