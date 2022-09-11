using ArticleManager.Web.Models;
using ArticleManager.Web.Services;
using Microsoft.AspNetCore.Components;
using Pin.Web.Blazor.Models;

namespace ArticleManager.Web.Pages
{
public partial class Articles
{
    [Inject]
    private ICRUDService<Article> articleService { get; set; }
    [Inject]
    private ICRUDService<Category> categoryService { get; set; }

    private ItemListModel<Article> listModel = new ItemListModel<Article>
    {
        ItemName = "Article",
        Headers = new[] { nameof(Article.Id), nameof(Article.Title), nameof(Article.CategoryName) },
        Items = new Article[0]
    };

    private ItemDetailsModel<Article> currentArticle = new ItemDetailsModel<Article>
    {
        ItemName = "Article"
    };

    private Category[] availableCategories = new Category[0];
    private string error;

    protected override async Task OnInitializedAsync()
    {
        await RefreshArticles();
    }

    public async Task RefreshArticles()
    {
        listModel.Items = (await articleService.GetAll()).ToArray();
        this.currentArticle.Item = null;
    }

    public async Task AddArticle()
    {
        this.availableCategories = (await categoryService.GetAll()).ToArray();
        this.currentArticle.Item = new Article();
    }

    public async Task EditArticle(Article item)
    {
        this.availableCategories = (await categoryService.GetAll()).ToArray();
        this.currentArticle.Item = await articleService.Get(item.Id);
    }

    public async Task SaveArticle(Article item)
    {
        try
        {
            if (currentArticle.Item.Id == 0)
            {
                await articleService.Create(currentArticle.Item);
            }
            else
            {
                await articleService.Update(currentArticle.Item);
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
