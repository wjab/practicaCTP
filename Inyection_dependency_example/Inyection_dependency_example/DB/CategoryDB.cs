using System.ComponentModel.DataAnnotations;

namespace Inyection_dependency_example.DB
{
    public class CategoryDB
    {
        [Key]
        public int IdCategory { get; set; }

        [Required]
        public required string CategoryName { get; set; }

    }
}
