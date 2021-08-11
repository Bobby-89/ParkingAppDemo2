using AutoMapper;
using ParkingApp.DTO;
using ParkingApp.Models;

namespace ParkingApp.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Car, CarDTO>();
            CreateMap<CarDTO, Car>();
            CreateMap<TicketDTO, Ticket>();
            CreateMap<Ticket, TicketDTO>();
        }
    }
}
