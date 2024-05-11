using AstralParserBack.DataContext;
using AstralParserBack.DataTransfer;
using AstralParserBack.Modules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace AstralParserBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly AppDataContext _context;

        public HistoryController(AppDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoryDto>>> GetHistory()
        {
            var historyData = await _context.history
                .Include(h => h.job)
                .Include(h => h.status)
                .Include(h => h.developer)
                .ToListAsync();

            if (historyData == null)
            {
                return NotFound();
            }

            var historyDtoList = historyData.Select(h => new HistoryDto
            {
                DeveloperSurname = h.developer.surename,
                DeveloperFirstName = h.developer.firstname,
                DeveloperFatherName = h.developer.fathername,
                BuildTime = h.buildtime,
                JobName = h.job.jobname,
                StatusName = h.status.name
            }).ToList();

            return historyDtoList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<history>> GetHistory(int id)
        {
            var history = await _context.history.Include(h => h.job).Include(h => h.status).FirstOrDefaultAsync(h => h.id == id);

            if (history == null)
            {
                return NotFound();
            }

            return history;
        }
    }
}
