using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Entities;
using StudentHive.Services.Features.RentalHouses;

namespace StudentHive.Controller.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalHouseController : ControllerBase //with the api controller we use the services and we can use http petitions 
    {
        public readonly RentalHouseService _rentalHouseService;
            public readonly IMapper _mapper;

        public RentalHouseController( RentalHouseService rentalHouseService, IMapper mapper )
        {
            this._rentalHouseService = rentalHouseService;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var rentalHouses = _rentalHouseService.GetAll();

            var rentalHouseServiceDtos = _mapper.Map<IEnumerable<RentalHouseDTO>>(rentalHouses);
            return Ok( rentalHouseServiceDtos ); 
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var RentalHouse = _rentalHouseService.GetById(id); 
            if( RentalHouse.ID_Publication <= 0  ) 
            return NotFound();

            var RentalHouseDto = _mapper.Map<RentalHouseDTO>( RentalHouse );

            return Ok( RentalHouseDto );
        }

        [HttpPost]
        public IActionResult Add(RentalHouseCreateDTO RentalHouse) 
        {
            //*we need to add the new id of de new RentalHouse
            var RentalHouseCreateDtoToEntity = _mapper.Map<RentalHouse>(RentalHouse);
            RentalHouse RentalHouseEntity = RentalHouseCreateDtoToEntity;

            var RentalHouses = _rentalHouseService.GetAll();
            var RentalHouseId = RentalHouses.Count() + 1;

            RentalHouseEntity.ID_Publication = RentalHouseId;
            _rentalHouseService.Add(RentalHouseEntity);

            return CreatedAtAction( nameof( GetById ), new { id = RentalHouseEntity.ID_Publication }, RentalHouseEntity );

        }

        // [HttpPut]
        // public IActionResult Update( int id, RentalHouse rentalHouse )
        // {
        //     if( id != rentalHouse.ID_Publication )
        //         return BadRequest();

        //     _rentalHouseService.update( rentalHouse ); 
        //     return NoContent();
        // }

        [HttpDelete("{id}")] // this only define the route 
        public IActionResult Delete( int id )  
        {
            _rentalHouseService.Delete( id );
            return NoContent();
        }
    }
}

