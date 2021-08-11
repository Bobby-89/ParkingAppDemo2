using System.Collections.Generic;

namespace ParkingApp.DTO
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string LicenseNumber { get; set; }

        // Foreign key for ParkingLot
        //public int ParkingLotId { get; set; }
        //public ParkingLotDTO ParkingLotDTO { get; set; }

        public ICollection<TicketDTO> Tickets { get; set; }
    }
}
