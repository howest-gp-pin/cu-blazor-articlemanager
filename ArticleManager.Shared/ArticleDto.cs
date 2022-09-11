namespace ArticleManager.Shared
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public CategoryDto Category { get; set; }
        public string Content { get; set; }
    }
}
