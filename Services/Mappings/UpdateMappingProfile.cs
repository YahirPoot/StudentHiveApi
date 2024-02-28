using AutoMapper;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Entities;

namespace StudentHive.Services.Mappings;

public class UpdateMappingProfile : Profile 
{
    public UpdateMappingProfile() 
    {
                    // =>     new User entity
        CreateMap<UserUpdateDTO,User>();

    }
}