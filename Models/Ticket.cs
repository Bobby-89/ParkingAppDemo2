using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Models
{
    public class Ticket
    {
        public Ticket(Car car)
        {
            this.CarId = car.Id;
            this.EnterTime = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime EnterTime { get; set; }
        public DateTime ExitTime { get; set; }
        public decimal Price { get; set; }
        public int CarId { get; set; }
    }
}
