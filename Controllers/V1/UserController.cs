using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Entities;
using StudentHive.Services.Features.Users;

namespace StudentHive.Controllers.V1
{
    //! These are the entry and exit point
    //*Here i begin to work with my DTO and mappers. 
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase // this is the part that i show in the swagger. too in this part we consume the services layer
    {
        public readonly UsersService _usersService;//This is to use all the logic of the program
        public readonly IMapper _mapper;

        public UserController( UsersService usersService, IMapper mapper )
        {
            this._usersService = usersService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Users = await _usersService.GetAll(); // <--- i did use of my _userServices 
            var UserDtos = _mapper.Map<IEnumerable<UserDTO>>(Users); //* Here i convert my entities to a List<UserDTO>
            return Ok( UserDtos ); //*i show my userDtos
        }

        [HttpGet("{id}")] //? <--- this is the form that we will watch the Url.
        public async Task<IActionResult> GetById(int id) 
        {
            var User = await _usersService.GetById(id); 
            if( User.IdUser <= 0 ) 
            return NotFound();

            var UserToUserDto = _mapper.Map<UserDTO>(User);

            return Ok( UserToUserDto );
        }

        [HttpPost("login")]
        public async Task<IActionResult> AuthLogin(AuthLoginDTO authLogin)
        {
            var user = await _usersService.AuthLogin(authLogin);
            //* si me regresa una sentencia user() vacia tendrá id = 0
            if (user.IdUser <= 0)
                return BadRequest("Invalid email or password");

            var dto = _mapper.Map<UserDTO>(user);
            dto.Token = _usersService.GenerateToken(user);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add( UserCreateDTO UserCreateDto ) 
        {                        // User <= UserCreateDto       // src <= dest    
            var Entity = _mapper.Map<User>(UserCreateDto); 
            Entity.Password = _usersService.HashPassword( Entity.Password );

            await _usersService.Add(Entity);

            var userDto = _mapper.Map<UserDTO>( Entity ); //I converted my entity to show my UserDto on the swagger

            return CreatedAtAction( nameof( GetById ), new { id = Entity.IdUser }, userDto); //? <--- i don´t know nothing of this.
        }

    }
}