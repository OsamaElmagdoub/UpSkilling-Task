using System.ComponentModel.DataAnnotations;

namespace UpSkilling_Task.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        //public ICollection<Book> Books { get; set; }
    }
}
