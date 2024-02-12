using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeacherWebApp.Data;
using TeacherWebApp.Models;

namespace TeacherWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachesController : ControllerBase
    {
        private readonly StudentDbContext _context;

        public TeachesController(StudentDbContext context)
        {
            _context = context;
        }

        // GET: api/Teaches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teach>>> GetTeach()
        {
          if (_context.Teach == null)
          {
              return NotFound();
          }
            return await _context.Teach.ToListAsync();
        }

        // GET: api/Teaches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teach>> GetTeach(int id)
        {
          if (_context.Teach == null)
          {
              return NotFound();
          }
            var teach = await _context.Teach.FindAsync(id);

            if (teach == null)
            {
                return NotFound();
            }

            return teach;
        }

        // PUT: api/Teaches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeach(int id, Teach teach)
        {
            if (id != teach.SId)
            {
                return BadRequest();
            }

            _context.Entry(teach).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeachExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Teaches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Teach>> PostTeach(Teach teach)
        {
          if (_context.Teach == null)
          {
              return Problem("Entity set 'StudentDbContext.Teach'  is null.");
          }
            _context.Teach.Add(teach);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeach", new { id = teach.SId }, teach);
        }

        // DELETE: api/Teaches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeach(int id)
        {
            if (_context.Teach == null)
            {
                return NotFound();
            }
            var teach = await _context.Teach.FindAsync(id);
            if (teach == null)
            {
                return NotFound();
            }

            _context.Teach.Remove(teach);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeachExists(int id)
        {
            return (_context.Teach?.Any(e => e.SId == id)).GetValueOrDefault();
        }
    }
}
