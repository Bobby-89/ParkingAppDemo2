using System.Collections.Generic;

namespace ParkingApp.DTO
{
    public class ParkingLotDTO
    {
        public int Id { get; set; }
        public string Address { get; set; }

        public ICollection<CarDTO> Cars { get; set; }
    }
}
