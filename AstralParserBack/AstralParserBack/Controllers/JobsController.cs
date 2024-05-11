using AstralParserBack.DataContext;
using AstralParserBack.Modules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AstralParserBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly AppDataContext _context;

        public JobsController(AppDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<job>>> GetJobs()
        {
            return await _context.jobs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<job>> GetJob(int id)
        {
            var job = await _context.jobs.FindAsync(id);

            if (job == null)
            {
                return NotFound();
            }

            return job;
        }
    }
}
