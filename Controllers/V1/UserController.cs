using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Entities;
using StudentHive.Services.Features.Users;

namespace StudentHive.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase // this is the part that i show in the swagger. too in this part we consume the services layer
    {
        public readonly UsersService _usersService;
        public readonly IMapper _mapper;

        public UserController( UsersService usersService, IMapper mapper )
        {
            this._usersService = usersService;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var Users = _usersService.GetAll();
            var UserDtos = _mapper.Map<IEnumerable<UserDTO>>(Users); //* Here i convert my entity to a List<UserDTO>
            return Ok( UserDtos );
        }

        [HttpGet("{id}")] //? <--- this is the form that we will watch the Url.
        public IActionResult GetById(int id) 
        {
            var User = _usersService.GetById(id); 
            if( User.ID_User <= 0 ) 
            return NotFound();

            var UserToUserDto = _mapper.Map<UserDTO>(User);

            return Ok( UserToUserDto );
        }

        [HttpPost]
        public IActionResult Add( UserCreateDTO User ) 
        {
            var UserDtoToEntity = _mapper.Map<User>(User); //Convert my UserCreateDTO to Entity of User
            User UserEntity = UserDtoToEntity;

            var Users = _usersService.GetAll(); //These are all my users.
            var UserId = Users.Count() + 1; //i am generating the id for the user.

            UserEntity.ID_User = UserId; //here I am adding the id of the new User.

            _usersService.Add(UserEntity);

            return CreatedAtAction( nameof( GetById ), new { id = UserEntity.ID_User }, UserEntity ); //? <--- i don´t know nothing of this.
        }

        [HttpPut]
        public IActionResult Update( int id, UserUpdateDTO UserDTO )
        {
            var existingUser = _usersService.GetById(id);
            if (existingUser == null)
                return NotFound();

            if (!string.IsNullOrEmpty(UserDTO.PhoneNumber))
            {
                existingUser.PhoneNumber = UserDTO.PhoneNumber;

            }
            if (!string.IsNullOrEmpty(UserDTO.ProfilePhotoUrl)) 
            {
                existingUser.ProfilePhotoUrl = UserDTO.ProfilePhotoUrl;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete( int id )  
        {

            _usersService.Delete( id );
            return NoContent();
        }
    }
}