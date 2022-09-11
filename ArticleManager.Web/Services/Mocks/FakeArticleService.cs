using ArticleManager.Web.Models;

namespace ArticleManager.Web.Services.Mocks
{
    public class FakeArticleService : ICRUDService<Article>
    {
        static List<Article> articles = new List<Article>{
            new Article() { Id = 1, Title = "Title 1", CategoryId = 1, Content = "Content 1" },
            new Article() { Id = 2, Title = "Title 2", CategoryId = 2, Content = "Content 2" },
            new Article() { Id = 3, Title = "Title 3", CategoryId = 3, Content = "Content 3" },
        };

        private readonly ICRUDService<Category> categoryService;

        public FakeArticleService(ICRUDService<Category> categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<Article> Get(int id)
        {
            var categories = await categoryService.GetAll();

            return articles.Select(a => new Article
            {
                Id = a.Id,
                Content = a.Content,
                Title = a.Title,
                CategoryId = a.CategoryId,
                CategoryName = categories.SingleOrDefault(e => e.Id.Equals(a.CategoryId)).Name,
            })
            .SingleOrDefault(x => x.Id == id);
        }

        public async Task<IQueryable<Article>> GetAll()
        {
            var categories = await categoryService.GetAll();
            return articles
                .Select(a => new Article
                {
                    Id = a.Id,
                    Content = a.Content,
                    Title = a.Title,
                    CategoryId = a.CategoryId,
                    CategoryName = categories.SingleOrDefault(e => e.Id.Equals(a.CategoryId)).Name,
                }).AsQueryable();
        }

        public Task Create(Article item)
        {
            item.Id = articles.Count() > 0 ? articles.Max(x => x.Id) + 1 : 1;
            articles.Add(item);
            return Task.CompletedTask;

        }

        public Task Update(Article item)
        {
            var article = articles.SingleOrDefault(x => x.Id == item.Id);
            if (article == null) throw new ArgumentException("Article not found!");
            article.Title = item.Title;
            article.CategoryId = item.CategoryId;
            article.Content = item.Content;
            return Task.CompletedTask;

        }

        public Task Delete(int id)
        {
            var article = articles.SingleOrDefault(x => x.Id == id);
            if (article == null) throw new ArgumentException("Article not found!");
            articles.Remove(article);
            return Task.CompletedTask;
        }
    }
}
