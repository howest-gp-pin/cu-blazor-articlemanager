using ArticleManager.Web.Models;
using ArticleManager.Web.Services;
using Microsoft.AspNetCore.Components;

namespace ArticleManager.Web.Pages
{
    public partial class Articles
    {
        [Inject]
        private ICRUDService<Article> articleService { get; set; }
        [Inject]
        private ICRUDService<Category> categoryService { get; set; }

        private Article currentArticle;
        private Article[] articles = new Article[0];
        private Category[] availableCategories = new Category[0];
        private string error;

        protected override async Task OnInitializedAsync()
        {
            await RefreshArticles();
        }

        public async Task RefreshArticles()
        {
            articles = (await articleService.GetAll()).ToArray();
            this.currentArticle = null;
        }

        public async Task AddArticle()
        {
            this.availableCategories = (await categoryService.GetAll()).ToArray();
            this.currentArticle = new Article();
        }

        public async Task EditArticle(Article item)
        {
            this.availableCategories = (await categoryService.GetAll()).ToArray();
            this.currentArticle = await articleService.Get(item.Id);
        }

        public async Task SaveArticle(Article item)
        {
            try
            {
                if (currentArticle.Id == 0)
                {
                    await articleService.Create(currentArticle);
                }
                else
                {
                    await articleService.Update(currentArticle);
                }
                await this.RefreshArticles();
            }
            catch (Exception ex)
            {
                this.error = ex.Message;
            }
        }

        public async Task DeleteArticle(Article item)
        {
            try
            {
                await articleService.Delete(item.Id);
                await this.RefreshArticles();
            }
            catch (Exception ex)
            {
                this.error = ex.Message;
            }
        }
    }
}
