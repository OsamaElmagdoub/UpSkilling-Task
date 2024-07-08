using System.ComponentModel.DataAnnotations;
using UpSkilling_Task.Entities;

namespace UpSkilling_Task.Dto
{
    public class BookDto
    {

        public string Name { get; set; }
        public string Description { get; set; }

        public double Price { get; set; }
        public string Auther { get; set; }

        public int stock { get; set; }
        public int CategoryId { get; set; }



    }
}
