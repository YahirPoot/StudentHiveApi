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

    public async Task<User> GetById( int Userid )//* The user will add the id to find a user from the list _User.id
    {
        return await _UserRepository.GetById( Userid );

    }

    public async Task Add( User user )
    {
        await _UserRepository.Add( user );
    }

    public async Task Update( User user ) //i add the new user for to update
    { 
        await _UserRepository.Update(user);
    }

}