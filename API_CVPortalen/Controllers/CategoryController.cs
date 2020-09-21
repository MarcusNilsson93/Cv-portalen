using System.Linq;
using System.Threading.Tasks;
using API_CVPortalen.Helpers.Programmes;
using API_CVPortalen.Models.Auth;
using API_CVPortalen.Models.Database;
using API_CVPortalen.Models.Programme;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_CVPortalen.Controllers
{
    [ApiController]
    [Route("api/programme/[controller]")]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly Context _context;
        public CategoryController(Context context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _context.ProgrammeCategories.FindAsync(id);
            
            if (category == null) { return NotFound(); }

            return Ok(category);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _context.ProgrammeCategories.ToListAsync();
            return Ok(categories);

        }
        [HttpPut("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> UpdateProgramme(int id, ProgrammeCategory category)
        {
            if (id != category.ProgrammeCategoryId)
            {
                return BadRequest();
            }

            var _category = await _context.ProgrammeCategories.FindAsync(id);
            if (_category == null)
            {
                return NotFound();
            }

            if (_category.ProgrammeCategoryId != category.ProgrammeCategoryId)
            {
                _category.ProgrammeCategoryId = category.ProgrammeCategoryId;
            }

            if (!string.IsNullOrEmpty(category.Name))
            {
                _category.Name = category.Name;
            }
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!CategoryExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.ProgrammeCategories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.ProgrammeCategories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> CreateCategory(ProgrammeCategory category)
        {
            await _context.ProgrammeCategories.AddAsync(category);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCategory), new {id = category.ProgrammeCategoryId}, category);
        }
        private bool CategoryExists(int id) => _context.ProgrammeCategories.Any(p => p.ProgrammeCategoryId == id);
    }
}