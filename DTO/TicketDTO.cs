using System;

namespace ParkingApp.DTO
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public DateTime EnterTime { get; set; }
        public DateTime ExitTime { get; set; }
        public decimal Price { get; set; }
        public bool IsPaid { get; set; }

        // Foreign key for Car
        //public int CarDTOId { get; set; }
        public CarDTO CarDTO { get; set; }
    }
}
