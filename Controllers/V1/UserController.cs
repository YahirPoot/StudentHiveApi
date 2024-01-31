using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentHive.Domain.Entities;
using StudentHive.Services.Features.Users;

namespace StudentHive.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public readonly UsersService _usersService;

        public UserController( UsersService usersService )
        {
            this._usersService = usersService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok( _usersService.GetAll() );
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute]int id) //? <--- the same with this
        {
            var User = _usersService.GetById(id); //* <--- here i´m using the rentalHouseService :) 
            if( User == null  ) 
            return NotFound();

            return Ok( User );
        }

        [HttpPost]
        public IActionResult Add([FromBody] User user)  //? <--- i don´t know nothing of this.
        {
            _usersService.Add( user ); //* <--- here i´m using the rentalHouseService :) 
            return CreatedAtAction( nameof( GetById ), new { id = user.UserId }, user );
        }

        [HttpPut]
        public IActionResult Update( int id, User user )
        {
            if( id != user.UserId )
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