using ParkingApp.DTO;
using ParkingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Services
{
    public interface ITicketService
    {
        public Task<TicketDTO> GetTicketByCarId(int? id);
        public Task<bool> Pay(int ticketId);
        public Task<Ticket> Exit(int? id);
        public Task Create(Ticket ticket);
    }
}
