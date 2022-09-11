using ArticleManager.Shared;
using ArticleManager.WebApi.Data;
using ArticleManager.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArticleManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ArticlesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Articles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleDto>>> GetArticles()
        {
            return await _context.Articles
                .Include(e => e.Category)
                .Select(e => new ArticleDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    Content = e.Content,
                    Category = new CategoryDto
                    {
                        Id = e.Category.Id,
                        Name = e.Category.Name,
                        Description = e.Category.Description,
                    }
                })
                .ToListAsync();
        }

        // GET: api/Articles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleDto>> GetArticle(int id)
        {
            var article = await _context.Articles
                .Where(e => e.Id == id)
                .Select(e => new ArticleDto()
                {
                    Id = e.Id,
                    Title = e.Title,
                    Content = e.Content,
                    Category = new CategoryDto
                    {
                        Id = e.Category.Id,
                        Name = e.Category.Name,
                        Description = e.Category.Description,
                    }
                })
                .SingleOrDefaultAsync();

            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        // PUT: api/Articles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticle(int id, ArticleDto dto)
        {
            if (ModelState.IsValid)
            {
                var entity = _context.Articles.SingleOrDefault(x => x.Id == id);
                if (entity == null) return NotFound();
                entity.Title = dto.Title;
                entity.Content = dto.Content;
                entity.CategoryId = dto.Category.Id;
                await _context.SaveChangesAsync();
                return Ok(entity);
            }
            return BadRequest(ModelState);
        }

        // POST: api/Articles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArticleDto>> PostArticle(ArticleDto dto)
        {
            if (ModelState.IsValid)
            {
                var entity = new Article()
                {
                    Title = dto.Title,
                    Content = dto.Content,
                    CategoryId = dto.Category.Id,
                };
                _context.Add(entity);
                await _context.SaveChangesAsync();
                dto.Id = entity.Id;
                return CreatedAtAction(nameof(PostArticle), new { id = entity.Id }, dto);
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Articles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var entity = _context.Articles.SingleOrDefault(x => x.Id == id);
            if (entity == null) return NotFound();
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return Ok(entity);
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.Id == id);
        }
    }
}
