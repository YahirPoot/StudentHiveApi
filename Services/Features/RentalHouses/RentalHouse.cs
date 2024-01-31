using StudentHive.Domain.entities;

namespace StudentHive.Services.Features.RentalHouses;

    public class RentalHouseService 
    {
        private readonly List<RentalHouse> _RentalHouses;// readonly is similar to final of Dart

        public RentalHouseService() // _RentalHouses added in the constructor class
        {
            _RentalHouses = new(); // i just initialed  the variable to won´t be null 
        }

        public IEnumerable<RentalHouse> GetAll() //IEnumerable is to iterate a list - similar to a mapper   
        {
            return _RentalHouses;
        }

        public RentalHouse GetById( int id )
        {
            var rentalHouse = _RentalHouses.FirstOrDefault(rh => rh.ID_Publication == id);
            if (rentalHouse == null)
            {
                throw new InvalidOperationException($"RentalHouse with ID {id} not found.");
            }
            return rentalHouse;
        }

        public void Add( RentalHouse rentalHouse )
        {
            _RentalHouses.Add(rentalHouse);
        }

        public void update( RentalHouse rentalHouseToUpdate )
        {
            var rentalHouse = GetById( rentalHouseToUpdate.ID_Publication ); // this get a rentalHouse by id to can update that rentalHouse

            if( rentalHouse != null){
                _RentalHouses.Remove(rentalHouse);
                _RentalHouses.Add(rentalHouseToUpdate);
            }
        }

        public void delete( int id )
        {
            var rentalHouse = GetById( id );
            if( rentalHouse != null ){
                _RentalHouses.Remove(rentalHouse);
            }
        }
    }
