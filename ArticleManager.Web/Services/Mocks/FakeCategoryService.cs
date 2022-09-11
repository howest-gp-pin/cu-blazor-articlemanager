using ArticleManager.Web.Models;

namespace ArticleManager.Web.Services.Mocks
{
    public class FakeCategoryService : ICRUDService<Category>
    {
        static List<Category> categories = new List<Category>{
            new Category() { Id = 1, Name = "Category 1", Description = "Description 1" },
            new Category() { Id = 2, Name = "Category 2", Description = "Description 2" },
            new Category() { Id = 3, Name = "Category 3", Description = "Description 3" },
        };

        public Task<Category> Get(int id)
        {
            return Task.FromResult(
                categories.SingleOrDefault(x => x.Id == id)
            );
        }

        public Task<IQueryable<Category>> GetAll()
        {
            return Task.FromResult(
                categories.AsQueryable()
            );
        }

        public Task Create(Category item)
        {
            item.Id = categories.Count() > 0 ? categories.Max(x => x.Id) + 1 : 1;
            categories.Add(item);
            return Task.CompletedTask;

        }

        public Task Update(Category item)
        {
            var category = categories.SingleOrDefault(x => x.Id == item.Id);
            if (category == null) throw new ArgumentException("Category not found!");
            category.Name = item.Name;
            category.Description = item.Description;
            return Task.CompletedTask;

        }
        public Task Delete(int id)
        {
            var category = categories.SingleOrDefault(x => x.Id == id);
            if (category == null) throw new ArgumentException("Category not found!");
            categories.Remove(category);
            return Task.CompletedTask;
        }

    }
}
