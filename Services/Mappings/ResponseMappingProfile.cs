using AutoMapper;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Dtos.AdminDtos;
using StudentHive.Domain.Entities;

namespace StudentHive.Services.Mappings;

public class ResponseMappingProfile : Profile 
{
    public ResponseMappingProfile() //this is how I want my entity to be transformed into a DTO
    {       //User => UserDTO
        // CreateMap<User,UserDTO>()
        //     .ForMember( dest => dest.IdUser, opt => opt.MapFrom( src => src.IdUser ));

        // CreateMap<RentalHouse,RentalHouseDTO>()
        //     .ForMember(dest => dest.DetailRentalHouse, opt => opt.MapFrom(src => src.IdRentalHouseDetailNavigation))
        //     .ForMember(dest => dest.HouseService, opt => opt.MapFrom(src => src.IdHouseServiceNavigation))
        //     .ForMember(dest => dest.TypeHouseRental, opt => opt.MapFrom(src => src.IdTypeHouseRentalNavigation))
        //     .ForMember(dest => dest.HouseLocation, opt => opt.MapFrom(src => src.IdHouseLocationNavigation));
        
        
        // CreateMap<RentalHouseDetail, RentalHouseDetailDTO>(); 

        // CreateMap<TypeHouseRental, TypeHouseRentalDTO>(); 

        // CreateMap<HouseService, HouseServiceDTO>();

        // CreateMap<HouseLocation, HouseLocationDTO>();
        
        //Administrador
        CreateMap<Administrador, MasterDto>()
        .ForMember(dest => dest.NombreRol, opt => opt.MapFrom(src => src.IdRolNavigation!.NombreRol));

    }
}