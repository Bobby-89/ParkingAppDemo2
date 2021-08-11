using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Models
{
    public class ParkingLot
    {
        public const int MaxCount = 15;

        public List<Car> ParkedCars = new List<Car>();

        public bool IsFull()
        {
            return ParkedCars.Count >= MaxCount;
        }

        public bool ParkCar(Car car)
        {
            if (IsFull())
            {
                return false;
            }

            ParkedCars.Add(car);

            return true;
        }

        public bool FreeParkingSlot(Car car)
        {
            return ParkedCars.Remove(car);
        }
    }
}
