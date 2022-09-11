using ArticleManager.Shared;
using ArticleManager.WebApi.Data;
using ArticleManager.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArticleManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            return await _context.Categories
                .Select(e => new CategoryDto
                {
                    Id = e.Id, 
                    Name = e.Name,
                    Description = e.Description
                })
                .ToListAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var category = await _context.Categories
                .Where(x => x.Id == id)
                .Select(x => new CategoryDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                })
                .SingleOrDefaultAsync();

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);

        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryDto dto)
        {
            if (ModelState.IsValid)
            {
                var entity = _context.Categories.SingleOrDefault(x => x.Id == id);
                if (entity == null) return NotFound();
                entity.Name = dto.Name;
                entity.Description = dto.Description;
                await _context.SaveChangesAsync();
                return Ok(entity);
            }
            return BadRequest(ModelState);
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> PostCategory(CategoryDto dto)
        {
            if (ModelState.IsValid)
            {
                var entity = new Category()
                {
                    Name = dto.Name,
                    Description = dto.Description,
                };
                _context.Add(entity);
                await _context.SaveChangesAsync();
                dto.Id = entity.Id;
                return CreatedAtAction(nameof(PostCategory), new { id = entity.Id }, dto);
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var entity = _context.Categories.SingleOrDefault(x => x.Id == id);
            if (entity == null) return NotFound();
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return Ok(entity);
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
