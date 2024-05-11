using Microsoft.AspNetCore.Mvc;
using AstralParserBack.DataContext;
using AstralParserBack.Modules;
using Microsoft.EntityFrameworkCore;

namespace AstralJenkinsParserBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly AppDataContext _context;

        public AdminsController(AppDataContext context)
        {
            _context = context;
        }

        [HttpPut("{id}/permission")] // Give permission developer to access JenkinsParser
        public IActionResult UpdateDeveloperPermission(int id, bool havePermission)
        {
            var developer = _context.developers.FirstOrDefault(d => d.id == id);
            if (developer == null)
            {
                return NotFound();
            }

            developer.havepermission = havePermission;
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("add-developer")] // Add new developer
        public async Task<ActionResult<developer>> AddDeveloper(developer newDeveloper)
        {
            _context.developers.Add(newDeveloper);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeveloper", new { id = newDeveloper.id }, newDeveloper); // Ошибка вывода, но работает. Колдунство в чистом виде
        }

        [HttpPost("add-admin")] // Add new admin
        public async Task<ActionResult<admin>> AddAdmin(admin newAdmin)
        {
            _context.admins.Add(newAdmin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdmin", new { id = newAdmin.id }, newAdmin);
        }

        [HttpGet] // Get all admins
        public async Task<ActionResult<IEnumerable<admin>>> GetAdmins()
        {
            return await _context.admins.ToListAsync();
        }

        [HttpGet("{id}")] // Get admin by id
        public async Task<ActionResult<admin>> GetAdmin(int id)
        {
            var admin = await _context.admins.FindAsync(id);

            if (admin == null)
            {
                return NotFound();
            }

            return admin;
        }
    }
}
