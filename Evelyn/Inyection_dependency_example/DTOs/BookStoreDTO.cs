
namespace Inyection_dependency_example.DTOs
{
    public class BookStoreDTO
    {
        public int IdBookStore { get; set; }

        public required string Name { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }
    }
}
