using ArticleManager.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArticleManager.WebApi.Data.Seeding
{
    public class CategorySeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Games",
                    Description = "Boardgames and computer games"
                },
                new Category
                {
                    Id = 2,
                    Name = "Books",
                    Description = "Enhance your programming skills"
                },
                new Category
                {
                    Id = 3,
                    Name = "Hardware",
                    Description = "Computer hardware"
                });
        }
    }
}
