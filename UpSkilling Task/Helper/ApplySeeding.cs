using Infrastructure;
using Microsoft.EntityFrameworkCore;
using UpSkilling_Task;

namespace Demo.Helper
{
    public class ApplySeeding
    {
        public static async Task ApplySeedingAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    var context = services.GetRequiredService<Context>();
                    await context.Database.MigrateAsync();
                    await StoreConrextSeed.SeedAsync(context, loggerFactory);
                }  
                catch (Exception ex)
                {

                    var logger = loggerFactory.CreateLogger<StoreConrextSeed>();
                    logger.LogError(ex.Message);
                }
            }
        }
    }
}
