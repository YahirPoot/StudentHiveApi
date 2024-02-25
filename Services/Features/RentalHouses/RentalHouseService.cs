using AutoMapper;
using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Repositories;

namespace StudentHive.Services.Features.RentalHouses;

public class RentalHouseService 
{
    private readonly RentalHouseRepository _rentalHouseRepository;
    private readonly IMapper _mapper;

    public RentalHouseService(RentalHouseRepository rentalHouseRepository, IMapper mapper)
    {
        this._rentalHouseRepository = rentalHouseRepository;
        this._mapper = mapper;
    }

    public async Task<IEnumerable<RentalHouse>> GetAll()
    {
        var rentalHouses = await _rentalHouseRepository.GetAll();
        return rentalHouses;
    }

    public async Task<RentalHouse> GetById(int id)
    {
        var rentalHouse = await _rentalHouseRepository.GetById(id);
        return rentalHouse;
    }

    public async Task Add(RentalHouse rentalHouse)
    {
        await _rentalHouseRepository.Add(rentalHouse);
    }

    public async Task Update(RentalHouse rentalHouse)
    {
        await _rentalHouseRepository.Update(rentalHouse);
    }

    public async Task Delete(int id)
    {
        await _rentalHouseRepository.Delete(id);
    }
}