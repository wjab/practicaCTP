namespace Inyection_dependency_example.DTOs
{
    public class BookShelfDTO
    {
        public int IdBookShelf { get; set; }

        public required string CategoryName { get; set; }

        public int HallNumber { get; set; }
    }
}
