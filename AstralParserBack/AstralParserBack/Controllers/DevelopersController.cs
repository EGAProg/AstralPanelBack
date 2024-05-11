using AstralParserBack.DataContext;
using AstralParserBack.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AstralJenkinsParserBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly AppDataContext _context;

        public DevelopersController(AppDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<developer>>> GetDevelopers()
        {
            return await _context.developers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<developer>> GetDeveloper(int id)
        {
            var developer = await _context.developers.FindAsync(id);

            if (developer == null)
            {
                return NotFound();
            }

            return developer;
        }

        // Other CRUD actions can be added here
    }
}