using Microsoft.EntityFrameworkCore;
using StudentHive.Domain.Entities;

namespace StudentHive.Infrastructure.Repositories;

public class RentalHouseRepository
{
    private readonly StudentHiveDbContext _context;

    public RentalHouseRepository(StudentHiveDbContext context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<RentalHouse>> GetAll()
    {
        var rentalHouses = await _context.RentalHouses
            .Include(r => r.IdHouseServiceNavigation)
            .Include(r => r.IdLocationNavigation)
            .Include(r => r.IdRentalHouseDetailNavigation)
            .Include(r => r.IdTypeReportNavigation)
            .Include(r => r.IdUserNavigation)
            .ToListAsync();
        return rentalHouses;
    }

    public async Task<RentalHouse> GetById(int id)
    {
        var rentalHouse = await _context.RentalHouses.FirstOrDefaultAsync(rentalHouse => rentalHouse.IdPublication == id);
        return rentalHouse ?? new RentalHouse();
    }

    public async Task Add(RentalHouse rentalHouse)
    {
        await _context.AddAsync(rentalHouse);
        await _context.SaveChangesAsync();
    }

    public async Task Update(RentalHouse rentalHouse)
    {
        _context.RentalHouses.Update(rentalHouse);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var rentalHouse = await _context.RentalHouses.FirstOrDefaultAsync(r => r.IdPublication == id);
        if (rentalHouse != null)
        {
            _context.RentalHouses.Remove(rentalHouse);
            await _context.SaveChangesAsync();
        }
    }
}