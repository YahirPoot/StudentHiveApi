using AutoMapper;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Entities;

namespace StudentHive.Services.Mappings;

public class RequestCreateMappingProfile : Profile
{
    public RequestCreateMappingProfile() // everything i need to create a publication and add properties that the user does not to add.  
    {               // src                  dest
        CreateMap<RentalHouseCreateDTO, RentalHouse>()
        .AfterMap
        (
            (src, dest) => 
            {
                dest.PublicationDate = DateTime.Now;
            }
        );

        CreateMap<UserCreateDTO, User>();

        CreateMap<HouseServiceCreateDTO, HouseService>();

        CreateMap<LocationCreateDTO, Location>();

        CreateMap<RentalHouseDetailCreateDTO, RentalHouseDetail>();
        
        CreateMap<TypeHouseRentalCreateDTO, TypeHouseRental>();



    }
}