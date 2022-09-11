using ArticleManager.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArticleManager.WebApi.Data.Seeding
{
    public class ArticleSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasData(
                new Article { Id = 1, CategoryId = 1, Title = "Coloma", 
                              Content = "Search for gold in de California Gold Rush" },
                new Article { Id = 2, CategoryId = 1, Title = "Caverna", 
                              Content = "Examine mines and herd animals with your dwarves" },
                new Article { Id = 3, CategoryId = 1, Title = "Brass Birmingham", 
                              Content = "Connect your production cites with boats and trains." },
                new Article { Id = 4, CategoryId = 2, Title = "Mastering C#", 
                              Content = "Step-by-step guide written in a lucid language for mastering C#" },
                new Article { Id = 5, CategoryId = 2, Title = "Exploring Advanced Features in C#", 
                              Content = "Become a more productive programmer by leveraging the newest features available to you in C#. " },
                new Article { Id = 6, CategoryId = 2, Title = "Learn Microsoft Azure", 
                              Content = "Implement rich Azure SAAS-PAAS-IAAS ecosystems using containers, serverless services, and storage solutions" },
                new Article { Id = 7, CategoryId = 3, Title = "Monitor", 
                              Content = "Have a clear sight on your code" },
                new Article { Id = 8, CategoryId = 3, Title = "Mouse", 
                              Content = "Click your way to succes" },
                new Article { Id = 9, CategoryId = 3, Title = "Keyboard", 
                              Content = "Type great code" },
                new Article { Id = 10, CategoryId = 3, Title = "Cardreader", 
                              Content = "Scan all kinds of cards" }
            );
        }
    }
}
