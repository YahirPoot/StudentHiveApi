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

        CreateMap<User,UserDTO>()
            .ForMember(dest => dest.IdUser, opt => opt.MapFrom(src => src.IdUser ));

        CreateMap<RentalHouse,RentalHouseDTO>()
            .ForMember(dest => dest.IdRentalHouseDetailNavigation, opt => opt.MapFrom(src => src.IdRentalHouseDetailNavigation))
            .ForMember(dest => dest.IdHouseServiceNavigation, opt => opt.MapFrom(src => src.IdHouseServiceNavigation))
            .ForMember(dest => dest.IdLocationNavigation, opt => opt.MapFrom(src => src.IdLocationNavigation))
            .ForMember(dest => dest.IdTypeReportNavigation, opt => opt.MapFrom(src => src.IdTypeReportNavigation));


        CreateMap<RentalHouseDetail, RentalHouseDetailDTO>(); 


        CreateMap<HouseService, HouseServiceDTO>();

        CreateMap<Location, HouseLocationDTO>();
        
        //Administrador
        CreateMap<Administrador, MasterDto>()
        .ForMember(dest => dest.NombreRol, opt => opt.MapFrom(src => src.IdRolNavigation!.NombreRol));

    }
}