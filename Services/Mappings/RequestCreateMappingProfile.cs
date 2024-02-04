using AutoMapper;
using StudentHive.Domain.Dtos;
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
        );
        CreateMap<UserCreateDTO, User>();//*Validated
        CreateMap<RentalHouseDetailDTO, RentalHouseDetail>();//*Validated
        CreateMap<HouseServiceDTO,HouseService >();//*Validated
        // CreateMap<LocationCreateDTO, Location>();//x
        // CreateMap<TypeHouseRentalCreateDTO, TypeHouseRental>();//x
    }
}
