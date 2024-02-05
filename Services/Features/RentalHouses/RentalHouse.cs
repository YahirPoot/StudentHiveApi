using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Repositories;

namespace StudentHive.Services.Features.RentalHouses;

    public class RentalHouseService 
    {
        //we are going to use this list to store all the RentalHouses
        private readonly RentalHouseRepository _RentalHouseRepository;// readonly is similar to final of Dart 
        

        public RentalHouseService( RentalHouseRepository rentalHouseRepository ) // _RentalHouses added in the constructor class
        {
            _RentalHouseRepository = rentalHouseRepository;
        }

        public async Task<IEnumerable<RentalHouse>> GetAll() //IEnumerable is to iterate a list - similar to a mapper   
        {
            return await _RentalHouseRepository.GetAll();
        }

        public async Task<RentalHouse> GetById( int id )
        {
            var rentalHouse = await _RentalHouseRepository.GetById(id);
            if (rentalHouse == null)
            {
                throw new InvalidOperationException($"RentalHouse with ID {id} not found.");
            }
            return rentalHouse;
        }

        public async Task Add( RentalHouse rentalHouse )
        {
            await _RentalHouseRepository.Add(rentalHouse);
        }

        public async Task update( RentalHouse rentalHouseToUpdate )
        {
            var rentalHouse = GetById( rentalHouseToUpdate.IdPublication ); // this get a rentalHouse by id to can update that rentalHouse

            if( rentalHouse.Id > 0 ){
                await _RentalHouseRepository.Update(rentalHouseToUpdate);
            }
        }

        public async Task Delete( int id )
        {
            var rentalHouse = GetById( id );
            if( rentalHouse.Id > 0 ){
                await _RentalHouseRepository.Delete(id);
            }
        }
    }
