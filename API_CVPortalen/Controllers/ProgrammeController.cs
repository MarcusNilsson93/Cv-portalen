using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_CVPortalen.Helpers.Users;
using API_CVPortalen.Models;
using API_CVPortalen.Models.Auth;
using API_CVPortalen.Models.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_CVPortalen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProgrammeController : ControllerBase
    {
        private readonly Context _context;
        // GET
        public ProgrammeController(Context context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProgramme(int id)
        {
            var programme = await _context.Programmes.FindAsync(id);
            
            if (programme == null) { return NotFound(); }
            
            return Ok(programme);
        }
        [HttpGet("{id}/students")]
        public async Task<IActionResult> GetStudents(int id)
        {
            var programme = await _context.Programmes.FindAsync(id);
            
            if (programme == null) { return NotFound(); }

            var students = await _context.Users.Where(x => x.ProgrammeId == id).ToListAsync();
            
            return Ok(students.ToSafeResponse());
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var programmes = await _context.Programmes.ToListAsync();
            return Ok(programmes);
        }
        
        [HttpPut("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> UpdateProgramme(int id, Programme programme)
        {
            if (id != programme.Id)
            {
                return BadRequest();
            }

            var _programme = await _context.Programmes.FindAsync(id);
            if (_programme == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(programme.Name))
            {
                _programme.Name = programme.Name;
            }

            if (programme.Start != _programme.Start)
            {
                _programme.Start = programme.Start;
            }

            if (programme.End != _programme.End)
            {
                _programme.End = programme.End;
            }
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ProgrammeExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> DeleteProgramme(int id)
        {
            var programme = await _context.Programmes.FindAsync(id);
            if (programme == null)
            {
                return NotFound();
            }

            _context.Programmes.Remove(programme);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> CreateProgramme(Programme programme)
        {
            await _context.Programmes.AddAsync(programme);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProgramme), new {id = programme.Id}, programme);
        }

        private bool ProgrammeExists(int id) => _context.Programmes.Any(p => p.Id == id);
        private bool ProgrammeExists(string name) => _context.Programmes.Any(p => p.Name == name);
    }
}