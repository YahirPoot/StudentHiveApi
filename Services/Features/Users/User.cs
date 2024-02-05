using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Repositories;

namespace StudentHive.Services.Features.Users;
//* This is the layer that uses my database services
public class UsersService
{
    private readonly UserRepository _UserRepository;  

    public UsersService( UserRepository userRepository)
    {
        _UserRepository = userRepository;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _UserRepository.GetAll();
    }

    public async Task<User> GetById( int id )//* The user will add the id to find a user from the list _User.id
    {
        var user = await _UserRepository.GetById( id ); //? will return a true o false?

        if( user == null ){
            throw new InvalidOperationException($"User with ID {id} not found.");
        }
        return user;
    }

    public async Task Add( User user )
    {
        await _UserRepository.Add( user );
    }

    public async Task Update( User user ) //i add the new user for to update
    { 
       await _UserRepository.Update(user);
    }

    // public async Task Delete( int id ) //here the user will add an id?
    // {
    //     // var user = GetById( id ); 

    //     // if( user.Id >= 0 ){
    //         await _UserRepository.Delete(id);
    //     // }
    // }
}