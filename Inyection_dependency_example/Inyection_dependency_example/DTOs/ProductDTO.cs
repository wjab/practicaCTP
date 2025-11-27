namespace Inyection_dependency_example.DTOs
{
    public class ProductDTO
    {
        public int IdProduct { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public int? Amount { get; set; }

        public decimal? Worth { get; set; }

        public DateTime? Date_of_entry { get; set; }


    }
}
