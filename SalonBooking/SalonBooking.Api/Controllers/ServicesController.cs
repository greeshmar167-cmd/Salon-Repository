using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalonBooking.Api.Data;
using SalonBooking.Api.Models;

namespace SalonBooking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase


    {
        private readonly SalonDbContext _context;

        public ServicesController(SalonDbContext context)
        {
            _context = context;
        }

        // GET api/services
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var services = await _context.Services.ToListAsync();
            return Ok(services);
        }
    }
}
