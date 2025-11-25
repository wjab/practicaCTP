using System.ComponentModel.DataAnnotations;

namespace Inyection_dependency_example.DB
{
    public class BookShelfDB
    {
        [Key]
        public int IdBookShelf { get; set; }

        [Required]
        public required string CategoryName { get; set; }

        public int HallNumber {get; set; }

    }
}
