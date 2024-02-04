using StudentHive.Domain.Entities;

namespace StudentHive.Services.Features.Users;

public class UsersService
{
    private readonly List<User> _Users; //i´m using this list to add the users. 

    public UsersService(  )
    {
        _Users = new();
    }

    public IEnumerable<User> GetAll()
    {
        return _Users; // this will iterate all the _Users that it´s a list. 
    }

    public User GetById( int id )//* The user will add the id to find a user from the list _User.id
    {
        var user = _Users.FirstOrDefault( usr => usr.ID_User == id ); //? will return a true o false?

        if( user == null ){
            throw new InvalidOperationException($"User with ID {id} not found.");
        }
        return user;
    }

    public void Add( User user )
    {
        _Users.Add( user );
    }

    public void Update( User UserToUpdate ) //i add the new user for to update
    { 
        var user = GetById( UserToUpdate.ID_User );

        if( user != null ) //here we validate if the UserToUpdate isn´t null 
        {
            _Users.Remove( user );
            _Users.Add( UserToUpdate );
        }
    }

    public void Delete( int id ) //here the user will add an id?
    {
        var user = GetById( id ); 

        if( user != null ) 
        {
            _Users.Remove( user );
        }
    }
}