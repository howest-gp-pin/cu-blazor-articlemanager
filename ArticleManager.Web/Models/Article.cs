using System.ComponentModel.DataAnnotations;

namespace ArticleManager.Web.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Title is too long.")]
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Content { get; set; }

    }
}
