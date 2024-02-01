using StudentHive.Domain.Entities;

namespace StudentHive.Domain.Dtos;
//all the i need to create an user
public class UserCreateDTO { //this class is to create new users
    //i don´t add the ID_User because it is a value that is generated automatically when we create a user.
    public int User_Age { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!; 
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string? ProfilePhotoUrl { get; set; }
    public Gender GenderU { get; set; }
}   