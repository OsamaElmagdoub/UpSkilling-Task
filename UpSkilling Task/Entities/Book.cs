using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace UpSkilling_Task.Entities
{
    public class Book
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(1, int.MaxValue)]
        public double Price { get; set; }
        public string Auther { get; set; }

        [Range(1, int.MaxValue)]
        public int stock { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }



    }
}
