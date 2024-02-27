using AutoMapper;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Dtos.AdminDtos;
using StudentHive.Domain.Entities;

namespace StudentHive.Services.Mappings;

public class RequestCreateMappingProfile : Profile
{
    public RequestCreateMappingProfile()
    {             
          //src                   dest
        CreateMap<RentalHouse, PublicationDtos>();
        CreateMap<RentalHouseDetailCreateDTO, RentalHouseDetail>();//*Validated
        CreateMap<HouseServiceCreateDTO, HouseService>();//*Validated
        CreateMap<HouseLocationCreateDTO, Location>();//*Validated
        CreateMap<ImageRentalHouseCreateDTO, Image>();//*Validated


        CreateMap<RentalHouseCreateDTO, RentalHouse>()            //*Validated
        .AfterMap
        (
            (src, dest) => 
                {
                    dest.PublicationDate = DateTime.Now;
                }
        );//UserCreateDTO => User
        
        //Administrador
        CreateMap<Administrador, MasterDto>();
        CreateMap<CreateAdministradorDto, Administrador>()
        .AfterMap(
            (src, dest ) =>
            {
                dest.IdRol = 2;
            }
        );
    }
}
