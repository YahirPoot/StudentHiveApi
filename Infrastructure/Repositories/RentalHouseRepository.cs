// using System.Text.Json;
// using Microsoft.EntityFrameworkCore;
// using StudentHive.Domain.Entities;


// namespace StudentHive.Infrastructure.Repositories;

// public class RentalHouseRepository
// {
//     private readonly StudentHiveDbContext _context;
//     public RentalHouseRepository(StudentHiveDbContext context)
//     {
//             this._context = context;
//     }

//     public async Task<IEnumerable<RentalHouse>> GetAll()
//     {
//         var RentalHouses = await _context.RentalHouse
//         .Include( rh => rh.IdRentalHouseDetailNavigation)
//         .Include( rh => rh.IdHouseServiceNavigation)
//         .Include( rh => rh.IdHouseLocationNavigation)
//         .Include( rh => rh.IdTypeHouseRentalNavigation)
//         .ToListAsync();
//         return RentalHouses;
//     }

//     public async Task<RentalHouse> GetById(int id)
//     {
//         var RentalHouse = await _context.RentalHouse.FirstOrDefaultAsync(RentalHouse => RentalHouse.IdPublication == id);
//         return RentalHouse ?? new RentalHouse();
//     }
//     public async Task Add(RentalHouse rentalHouse)
//     {
//         await _context.AddAsync(rentalHouse);
//         await _context.SaveChangesAsync();
//     }

//     public async Task Update(RentalHouse updatedRentalHouse)
//     {
//         var RentalHouse = await _context.RentalHouse.FirstOrDefaultAsync(rentalHouse => rentalHouse.IdPublication == updatedRentalHouse.IdPublication);

//         if (RentalHouse != null)
//         {
//             _context.Entry(RentalHouse).CurrentValues.SetValues(updatedRentalHouse);
//             await _context.SaveChangesAsync();
//         }
//     }

//     public async Task Delete(int id)
//     {
//         var rentalHouse = await _context.RentalHouse.FirstOrDefaultAsync(rentalHouse => rentalHouse.IdPublication == id);
//         if (rentalHouse != null)
//         {
//             _context.RentalHouse.Remove(rentalHouse);
//             await _context.SaveChangesAsync();
//         }
//     }
// }