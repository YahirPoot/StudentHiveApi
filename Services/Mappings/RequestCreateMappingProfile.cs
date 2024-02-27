using AutoMapper;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Entities;

namespace StudentHive.Services.Mappings;

public class RequestCreateMappingProfile : Profile
{
    public RequestCreateMappingProfile()
    {               //src                   dest
        // CreateMap<RentalHouseCreateDTO, RentalHouse>()             //*Validated
        // .AfterMap
        // (
        //     (src, dest) => 
        //         {
        //             dest.PublicationDate = DateTime.Now;
        //         }
        // );//UserCreateDTO => User
        CreateMap<UserCreateDTO, User>()
        .ForMember(dest => dest.IdRol, opt => opt.MapFrom(src => 1));
        
        CreateMap<RentalHouseCreateDTO, RentalHouse>()
        .ForMember(dest => dest.IdLocationNavigation, opt => opt.MapFrom(src => src.HouseLocation));

        
        // CreateMap<RentalHouseDetailDTO, RentalHouseDetail>();//*Validated
        // CreateMap<HouseServiceDTO,HouseService >();//*Validated
        // CreateMap<TypeHouseRentalDTO, TypeHouseRental>();//*Validate
        // CreateMap<HouseLocationDTO,HouseLocation >();//*
        
    }
}
