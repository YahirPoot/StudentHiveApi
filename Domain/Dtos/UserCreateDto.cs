using StudentHive.Domain.Entities;

namespace StudentHive.Domain.Dtos;
//all the i need to create an user
public class UserCreateDTO {
    public int User_Age { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!; 
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public long PhoneNumber { get; set; }
    public string ProfilePhotoUrl { get; set; } = null!;
    public string? GenderU { get; set; }
}   