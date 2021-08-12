using ParkingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Services
{
    public interface IParkingService
    {
        public Task<List<Car>> GetAllParkedCars();
        public Task<Car> GetParkedCarById(int? id);
        public Task<bool> Park(Car car);
        public Task Exit(int id);
    }
}
