using AutoMapper;
using ParkingApp.DTO;
using ParkingApp.Models;

namespace ParkingApp.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarDTO>();
            CreateMap<CarDTO, Car>();
            CreateMap<TicketDTO, Ticket>();
            CreateMap<Ticket, TicketDTO>();
        }
    }
}
