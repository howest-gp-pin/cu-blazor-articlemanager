using ArticleManager.Shared;
using ArticleManager.Web.Models;
using System.Net.Http.Json;

namespace ArticleManager.Web.Services.Mocks
{
    public class CategoriesApiService : ICRUDService<Category>
    {
        private string baseUrl = "https://localhost:5003/api/categories";
        private readonly HttpClient _httpClient = null;

        public CategoriesApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Category> Get(int id)
        {
            var dto = await _httpClient.GetFromJsonAsync<CategoryDto>($"{baseUrl}/{id}");
            return new Category
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
            };
        }

        public async Task<IQueryable<Category>> GetAll()
        {
            var dtos = await _httpClient.GetFromJsonAsync<CategoryDto[]>($"{baseUrl}");
            return dtos.Select(dto => new Category
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
            }).AsQueryable();
        }

        public Task Create(Category item)
        {
            var dto = new CategoryDto
            {
                Name = item.Name,
                Description = item.Description
            };
            return _httpClient.PostAsJsonAsync<CategoryDto>($"{baseUrl}", dto);
        }

        public Task Update(Category item)
        {
            var dto = new CategoryDto
            {
                Name = item.Name,
                Description = item.Description
            };
            return _httpClient.PutAsJsonAsync<CategoryDto>($"{baseUrl}/{item.Id}", dto);

        }
        public Task Delete(int id)
        {
            return _httpClient.DeleteAsync($"{baseUrl}/{id}");
        }
    }
}
