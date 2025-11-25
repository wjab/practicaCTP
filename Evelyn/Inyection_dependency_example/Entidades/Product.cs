using System.ComponentModel.DataAnnotations;

namespace Inyection_dependency_example.Entidades
{
    public class Product
    {
        [Key]
        public int IdProduct { get; set; }

        [Required]
        [MaxLength(20)]
        public required string Name { get; set; }

        public string? Description { get; set; }

        public int? Amount { get; set; }

        public decimal? Worth { get; set; }

        public DateTime? Date_of_entry { get; set; }

        //public int? FkCategory { get; set; }

    }
}