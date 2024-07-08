using UpSkilling_Task;
using UpSkilling_Task.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class StoreConrextSeed
    {
        public static async Task SeedAsync(Context context,ILoggerFactory loggerFactory)
        {
            try
            {
                if (context.Categories != null && !context.Categories.Any())
                {
                    var categoriesData = File.ReadAllText("SeedData/category.json");
                    var categories = JsonSerializer.Deserialize<List<Category>>(categoriesData);

                    if (categories != null)
                    {
                        foreach (var category in categories)
                            await context.Categories.AddAsync(category);

                        await context.SaveChangesAsync();
                    }
                }

                if (context.Books !=null && !context.Books.Any()) 
                {
                    var booksData = File.ReadAllText("SeedData/books.json");
                    var books = JsonSerializer.Deserialize<List<Book>> (booksData);

                    if(books != null )  
                    {
                        foreach ( var book in books ) 
                            await context.Books.AddAsync(book);

                        await context.SaveChangesAsync();
                    }
                }



            }
            catch (Exception ex) {

                var logger = loggerFactory.CreateLogger<StoreConrextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
