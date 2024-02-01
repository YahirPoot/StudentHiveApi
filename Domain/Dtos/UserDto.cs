using StudentHive.Domain.Entities;

namespace StudentHive.Domain.Dtos;

public class UserDTO /* It's just for transferring data */
{
    public int ID_User { get; set; } //to create a User DTO we can add for an automatically form.
    public int User_Age { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!; 
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string? ProfilePhotoUrl { get; set; }
    public Gender GenderU { get; set; }

    
}