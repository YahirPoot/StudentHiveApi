using Microsoft.AspNetCore.Mvc;
using StudentHive.Domain.Entities;
using StudentHive.Services.Features.RentalHouses;

namespace StudentHive.Controller.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalHouseController : ControllerBase //with the api controller we use the services and we can use http petitions 
    {
        public readonly RentalHouseService _rentalHouseService;
        public RentalHouseController( RentalHouseService rentalHouseService )
        {
            this._rentalHouseService = rentalHouseService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok( _rentalHouseService.GetAll() ); //* <--- here i´m using the rentalHouseService :) 
        }

        [HttpGet("{id:int}")] //? <--- i don´t know why i need to put this or how to put it.
        public IActionResult GetById([FromRoute]int id) //? <--- the same with this
        {
            var rentalHouse = _rentalHouseService.GetById(id); //* <--- here i´m using the rentalHouseService :) 
            if( rentalHouse == null  ) 
            return NotFound();

            return Ok( rentalHouse );
        }

        [HttpPost]
        public IActionResult Add([FromBody] RentalHouse rentalHouse)  //? <--- i don´t know nothing of this.
        {
            _rentalHouseService.Add( rentalHouse ); //* <--- here i´m using the rentalHouseService :) 
            return CreatedAtAction( nameof( GetById ), new { id = rentalHouse.ID_Publication }, rentalHouse );
        }

        [HttpPut]
        public IActionResult Update( int id, RentalHouse rentalHouse )
        {
            if( id != rentalHouse.ID_Publication )
                return BadRequest();

            _rentalHouseService.update( rentalHouse ); //* <--- here i´m using the rentalHouseService :) 
            return NoContent();
        }

        [HttpDelete("{id}")] // this only define the route 
        public IActionResult Delete( int id )  
        {
            _rentalHouseService.Delete( id );
            return NoContent();
        }
    }
}


