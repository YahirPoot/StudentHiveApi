using static StudentHive.Domain.Entities.User;

namespace StudentHive.Domain.Dtos;

public class UserDTO /* It's just for transferring data */
{
    public int ID_User { get; set; }
    public int Age { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!; 
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string ProfilePhotoUrl { get; set; } = null!;
    public Gender GenderU { get; set; }

    
}