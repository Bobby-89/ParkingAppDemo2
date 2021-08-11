using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Models;
using ParkingApp.Services;

namespace ParkingApp.Controllers
{
    public class ParkingController : Controller
    {
        private readonly IParkingService _parkingService;
        private readonly ITicketService _ticketService;

        public ParkingController(IParkingService parkingService, ITicketService ticketService)
        {
            _parkingService = parkingService;
            _ticketService = ticketService;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            return View(await _parkingService.GetAllParkedCars());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedCars = await _parkingService.GetAllParkedCars();
               
            var car = parkedCars.FirstOrDefault(c => c.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Vehicles/Create
        public IActionResult Park()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Park([Bind("Id,LicenseNumber")] Car car)
        {
            if (ModelState.IsValid)
            {
                await _parkingService.Park(car);
                var ticket = new Ticket(car);
                await _ticketService.Create(ticket);
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _parkingService.GetParkedCarById(id);

            if (car == null)
            {
                return NotFound();
            }

            var ticket = await _ticketService.Exit(id);

            if (ticket == null)
            {
                return NotFound();
            }


            ViewModel viewModel = new ViewModel();
            viewModel.Car = car;
            viewModel.Ticket = ticket;
            return View(viewModel);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _parkingService.Exit(id);
            //await _ticketService.Pay(ticket.Id);
            return RedirectToAction(nameof(Index));
        }

        //private bool VehicleExists(int id)
        //{
        //    return _context.Vehicle.Any(e => e.Id == id);
        //}
    }
}
