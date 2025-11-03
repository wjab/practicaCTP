using System.ComponentModel.DataAnnotations;

namespace Inyection_dependency_example.DB
{
    public class BookStoreDB
    {
        [Key]
        public int IdBookStore { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Name {  get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email {  get; set; }

        public string? Address { get; set; }


        // Audit properties
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
