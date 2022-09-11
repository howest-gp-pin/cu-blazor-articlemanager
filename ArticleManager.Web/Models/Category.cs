using System.ComponentModel.DataAnnotations;

namespace ArticleManager.Web.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name is too long.")]
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

    }
}
