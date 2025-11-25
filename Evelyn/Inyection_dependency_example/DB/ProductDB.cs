using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inyection_dependency_example.DB
{
    public class ProductDB
    {
        [Key]
        public int IdProduct { get; set; }

        [Required]
        [MaxLength(20)]
        public required string Name { get; set; }

        public string? Description { get; set; }

        public int? Amount { get; set; }

        [Precision(18, 2)]
        [DefaultValue(0.0)]
        public decimal Worth { get; set; }

        public DateTime? Date_of_entry { get; set; }

        [ForeignKey("FkCategory")]
        public required CategoryDB Category { get; set; }

    }
}

