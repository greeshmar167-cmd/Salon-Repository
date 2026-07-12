using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalonBooking.Api.Data;

namespace SalonBooking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    // This controller handles service retrieval - it allows clients to view all available services.
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
