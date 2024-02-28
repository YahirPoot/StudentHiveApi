using StudentHive.Domain.Entities;

namespace StudentHive.Domain.Dtos;

public class CompleteUserInformationDTO //Estos son los datos por llenar
{
    public int? UserAge { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Description { get; set; }
    public long? PhoneNumber { get; set; }
    public string? ProfilePhotoUrl { get; set; }
    public byte? Genderu { get; set; }
}