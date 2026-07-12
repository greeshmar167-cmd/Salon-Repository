using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalonBooking.Api.Data;
using SalonBooking.Api.Models;

namespace SalonBooking.Api.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    // This controller handles appointment booking and retrieval
    public class AppointmentsController : ControllerBase
    {
        private readonly SalonDbContext _context;

        public AppointmentsController(SalonDbContext context)
        {
            _context = context;
        }

        // POST api/appointments/book

        [HttpPost("book")]
        public async Task<IActionResult> Book(Appointment model)
        {
            // Don’t allow double booking same service same time
            bool exists = await _context.Appointments.AnyAsync(a =>
                a.ServiceId == model.ServiceId &&
                a.Date.Date == model.Date.Date &&
                a.TimeSlot == model.TimeSlot);

            if (exists)
            {
                return BadRequest(new { message = "This time slot is already booked." });
            }

            _context.Appointments.Add(model);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Appointment booked successfully!" });
        }

        // GET api/appointments
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.Appointments
                .Include(a => a.Service)
                .ToListAsync();

            return Ok(list);
        }
    }
}
