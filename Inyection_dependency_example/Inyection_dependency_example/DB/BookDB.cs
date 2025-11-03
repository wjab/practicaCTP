using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inyection_dependency_example.DB
{
    public class BookDB
    {
        [Key]
        public int IdBook { get; set; }

        [Required]
        [MaxLength(100)]    
        public required string Title { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [MaxLength(100)]
        public required string Author { get; set; }
        public DateTime PublishedDate { get; set; }

        // Audit properties
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }


        // foreing keys
        [ForeignKey("FkBookShelf")]
        public required BookShelfDB BookShelf { get; set; }
    }
}
