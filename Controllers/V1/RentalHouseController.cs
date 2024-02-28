using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Entities;
using StudentHive.Services.Features.RentalHouses;

namespace StudentHive.Controller.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalHouseController : ControllerBase //manejas  la entrada y salida de datos
    //manejamos mappers y Dtos.
    {
        public readonly RentalHouseService _rentalHouseService;
            public readonly IMapper _mapper;

        public RentalHouseController( RentalHouseService rentalHouseService, IMapper mapper )
        {
            this._rentalHouseService = rentalHouseService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rentalHouses = await _rentalHouseService.GetAll();

            var rentalHouseServiceDtos = _mapper.Map<IEnumerable<RentalHouseDTO>>(rentalHouses);
            return Ok( rentalHouseServiceDtos ); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var RentalHouse = await _rentalHouseService.GetById(id); 
            if( RentalHouse.IdPublication <= 0  ) 
            return NotFound();

            var RentalHouseDto = _mapper.Map<RentalHouseDTO>( RentalHouse );

            return Ok( RentalHouseDto );
        }

        [HttpPost]
        public async Task<IActionResult> Add(RentalHouseCreateDTO RentalHouse) 
        {
            //*we need to add the new id of de new RentalHouse
            var RentalHouseCreateDtoToEntity = _mapper.Map<RentalHouse>(RentalHouse);
            RentalHouse RentalHouseEntity = RentalHouseCreateDtoToEntity;

            await _rentalHouseService.Add(RentalHouseEntity);

            var rentalHouseDto = _mapper.Map<RentalHouseDTO>(RentalHouseEntity);

            return CreatedAtAction( nameof( GetById ), new { id = RentalHouseEntity.IdPublication }, rentalHouseDto);

        }

        [HttpPut]
        public async Task<IActionResult> Update( int id, RentalHouse rentalHouse )
        {
            if( id != rentalHouse.IdPublication)
                return BadRequest();

            await _rentalHouseService.Update( rentalHouse ); 
            return NoContent();
        }

        [HttpDelete("{id}")] // this only define the route 
        public async Task<IActionResult> Delete( int id )  
        {
            await _rentalHouseService.Delete( id );
            return NoContent();
        }
    }
}

