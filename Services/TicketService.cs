using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Data;
using ParkingApp.DTO;
using ParkingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Services
{
    public class TicketService : ITicketService
    {
        private const decimal PricePerHour = 1.2m;

        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;

        public TicketService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private decimal CalculatePrice(TicketDTO ticket)
        {
            var timeSpan = ticket.EnterTime - ticket.ExitTime;
            var startedHours = timeSpan.Hours + 1;
            return startedHours * PricePerHour;
        }

        public async Task<Ticket> Exit(int? carId)
        {
            // get by id
            var ticketDTO = await GetTicketByCarId(carId);

            if (ticketDTO == null)
            {
                return null;
            }

            // set exit time
            ticketDTO.ExitTime = DateTime.Now;
            // set amount
            ticketDTO.Price = CalculatePrice(ticketDTO);
            // save to db
            _context.Add(ticketDTO);
            await _context.SaveChangesAsync();

            var ticket = _mapper.Map<Ticket>(ticketDTO);
            return ticket;
        }

        public async Task<TicketDTO> GetTicketByCarId(int? id)
        {
            var ticketDTO = await _context.Tickets.FirstOrDefaultAsync(t => t.CarDTO.Id == id);
            return ticketDTO;
        }

        public async Task<bool> Pay(int ticketId)
        {
            var ticketDTO = await _context.Tickets.FindAsync(ticketId);
            ticketDTO.IsPaid = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task Create(Ticket ticket)
        {
            var ticketDTO = _mapper.Map<TicketDTO>(ticket);
            _context.Add(ticketDTO);
            await _context.SaveChangesAsync();
        }
    }
}
