using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using StudentHive.Domain.Entities;


namespace StudentHive.Infrastructure.Repositories;
//*It is le logic of database services 
public class UserRepository
{
    private readonly StudentHiveDbContext _context; //*Here i am interactuanding with my database
    public UserRepository(StudentHiveDbContext context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<User>> GetAll()
    { //only returns users<Users>
        var Users = await _context.Users.ToListAsync();
        return Users;
    }

    public async Task<User> GetById(int id)
    {   //Of all the users this is finding an user.id equal to ( int id )
        var User = await _context.Users.FirstOrDefaultAsync(user => user.IdUser == id);
        return User ?? new User();
    }
    public async Task Add(User user)
    {
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task Update(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
}
    }

//     public async Task Delete(int id)
// {
//     var user = await _context.Users.FirstOrDefaultAsync(u => u.IdUser == id);
//     if (user != null)
//     {
//         _context.Users.Remove(user);
//         await _context.SaveChangesAsync();
//     }
// }

