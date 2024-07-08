using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UpSkilling_Task.Entities;

namespace UpSkilling_Task
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {


        }

       

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories{ get; set; }

    }
}
