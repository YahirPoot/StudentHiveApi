using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Entities;
using StudentHive.Services.Features.Users;

namespace StudentHive.Controllers.V1
{
    //* These are the entry and exit point
    //*Here i begin to work with my DTO and mappers. 

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public readonly UsersService _usersService;
        public readonly IMapper _mapper;
        public readonly ImageUploadService _imageUploadService;

        public UserController( UsersService usersService, IMapper mapper, ImageUploadService imageUploadService )
        {
            this._usersService = usersService;
            this._mapper = mapper;
            this._imageUploadService = imageUploadService;
        }

        [Authorize(Policy = "Usuario")] // --> Me esta pidiendo la autorizacion del tipo de rol
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Users = await _usersService.GetAll();
            var UserDtos = _mapper.Map<IEnumerable<UserDTO>>(Users);
            return Ok( UserDtos );
        }

        [Authorize(Policy = "Usuario")]
        [HttpGet("id/{id}")] //? <--- this is the form that we will watch the Url.
        public async Task<IActionResult> GetById(int id) 
        {
            var User = await _usersService.GetById(id); 
            if( User.IdUser <= 0 ) 
            return NotFound();

            var UserToUserDto = _mapper.Map<UserDTO>(User);

            return Ok( UserToUserDto );
        }

        [Authorize(Policy = "Usuario")]
        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var user = await _usersService.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound();
            }
            var UserToUserDto = _mapper.Map<UserDTO>(user);
            return Ok(UserToUserDto);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> AuthLogin(AuthLoginDTO authLogin)
        {   //me esta regresando la instancia del usuario que existe en la base de datos con el campo de rol
            var userToken = await _usersService.AuthLogin(authLogin);
            //* si me regresa una sentencia user() vacia tendrá id = 0
            if (userToken == "")
                return BadRequest("Invalid email or password");
            
            return Ok(userToken);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Add( UserCreateDTO UserCreateDto ) 
        {                        // User <= UserCreateDto       // src <= dest    
            var Entity = _mapper.Map<User>(UserCreateDto); 
            Entity.Password = _usersService.HashPassword( Entity.Password );

            await _usersService.Add(Entity);

            var userDto = _mapper.Map<UserDTO>( Entity ); //I converted my entity to show my UserDto on the swagger

            return CreatedAtAction( nameof( GetById ), new { id = Entity.IdUser }, userDto); //? <--- i don´t know nothing of this.
        }

        [HttpPut]
        public async Task<IActionResult> Update( int id, UserUpdateDTO userUpdateDto )
        {
                try
    {
        var existingUser = await _usersService.GetById(id);

        if (existingUser == null)
        {
            return NotFound();
        }
        existingUser.IdUser = existingUser.IdUser;
        existingUser.Name = userUpdateDto.Name;
        existingUser.LastName = userUpdateDto.LastName;
        existingUser.Email = userUpdateDto.Email;
        existingUser.PhoneNumber = userUpdateDto.PhoneNumber; 
        existingUser.ProfilePhotoUrl = userUpdateDto.ProfilePhotoUrl;
        existingUser.Genderu = userUpdateDto.GenderU;
        existingUser.UserAge = userUpdateDto.UserAge;
        //TODO: ADD VALIDATIONS - AFTER.
        await _usersService.Update(existingUser);

        return NoContent();
    }
    catch (Exception)
    {
        
        return StatusCode(500, "Internal server error");
    }
        }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> Delete( int id )  
        // {
        //     await _usersService.Delete(id);
        //     return NoContent();
        // }
    }
}