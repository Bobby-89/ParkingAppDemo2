using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Data;
using ParkingApp.DTO;
using ParkingApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Services
{
    public class ParkingService : IParkingService
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;

        public ParkingService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Exit(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }

        public async Task<Car> GetParkedCarById(int? id)
        {
            var carDTO = await _context.Cars.FindAsync(id);
            if (carDTO == null)
            {
                return null;
            }
            var car = _mapper.Map<Car>(carDTO);
            return car;
        }

        public async Task<List<Car>> GetAllParkedCars()
        {
            var cars = await _context.Cars
                .Select(c => _mapper.Map<Car>(c))
                .ToListAsync();
            return cars;
        }

        public async Task<bool> Park(Car car)
        {
            var parkedCar = GetParkedCarById(car.Id);

            if (parkedCar != null)
            {
                return false;
            }

            var carDTO = _mapper.Map<CarDTO>(car);
            _context.Add(carDTO);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
