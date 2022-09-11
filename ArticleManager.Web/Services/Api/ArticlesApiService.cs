using ArticleManager.Shared;
using ArticleManager.Web.Models;

namespace ArticleManager.Web.Services.Mocks
{
    public class ArticlesApiService : ICRUDService<Article>
    {
        private string baseUrl = "https://localhost:5003/api/articles";
        private readonly HttpClient _httpClient = null;

        public ArticlesApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Article> Get(int id)
        {
            var dto = await _httpClient.GetFromJsonAsync<ArticleDto>($"{baseUrl}/{id}");
            return new Article
            {
                Id = dto.Id,
                Title = dto.Title,
                Content = dto.Content,
                CategoryId = dto.Category.Id,
                CategoryName = dto.Category.Name,
            };
        }

        public async Task<IQueryable<Article>> GetAll()
        {
            var dtos = await _httpClient.GetFromJsonAsync<ArticleDto[]>($"{baseUrl}");
            return dtos.Select(dto => new Article
            {
                Id = dto.Id,
                Title = dto.Title,
                Content = dto.Content,
                CategoryId = dto.Category.Id,
                CategoryName = dto.Category.Name,
            }).AsQueryable();
        }

        public Task Create(Article item)
        {
            var dto = new ArticleDto
            {
                Title = item.Title,
                Content = item.Content,
                Category = new CategoryDto {
                    Id = item.CategoryId
                }
            };
            return _httpClient.PostAsJsonAsync<ArticleDto>($"{baseUrl}", dto);
        }

        public Task Update(Article item)
        {
            var dto = new ArticleDto
            {
                Title = item.Title,
                Content = item.Content,
                Category = new CategoryDto
                {
                    Id = item.CategoryId
                }
            };
            return _httpClient.PutAsJsonAsync<ArticleDto>($"{baseUrl}/{item.Id}", dto);

        }
        public Task Delete(int id)
        {
            return _httpClient.DeleteAsync($"{baseUrl}/{id}");
        }
    }
}
