
namespace Inyection_dependency_example.DTOs
{
    public class BookDTO
    {
        public int IdBook { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required string Author { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
