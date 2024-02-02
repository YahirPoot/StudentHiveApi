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
            User Entity = UserDtoToEntity;

            var Users = _usersService.GetAll(); //These are all my users.
            var UserId = Users.Count() + 1; //i am generating the id for the user.

            Entity.ID_User = UserId; //here I am adding the id of the new User.

            _usersService.Add(Entity);

            return CreatedAtAction( nameof( GetById ), new { id = Entity.ID_User }, Entity ); //? <--- i don´t know nothing of this.
        }

        [HttpPut]
        public IActionResult Update( int id, User user )
        {
            if( id != user.ID_User )
                return BadRequest();

            _usersService.Update( user ); //* <--- here i´m using the rentalHouseService :) 
            return NoContent();
        }

        [HttpDelete("{id}")] // this only define the route 
        public IActionResult Delete( int id )  
        {
            _usersService.Delete( id );
            return NoContent();
        }
    }
}