using AstralParserBack.DataContext;
using AstralParserBack.Modules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AstralParserBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private readonly AppDataContext _context;

        public StatusesController(AppDataContext context)
        {
            _context = context;
        }

        // GET: api/Statuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<status>>> GetStatuses()
        {
            return await _context.statuses.ToListAsync();
        }

        // GET: api/Statuses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<status>> GetStatus(int id)
        {
            var status = await _context.statuses.FindAsync(id);

            if (status == null)
            {
                return NotFound();
            }

            return status;
        }
    }
}
