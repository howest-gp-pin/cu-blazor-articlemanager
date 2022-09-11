using System.ComponentModel.DataAnnotations;

namespace ArticleManager.WebApi.Entities
{
    public class Article
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Content { get; set; }

    }
}
