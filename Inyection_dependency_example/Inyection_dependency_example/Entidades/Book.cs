namespace Inyection_dependency_example.Entidades
{
    public class Book
    {
        public int IdBook { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required string Author { get; set; }
        public DateTime PublishedDate {  get; set; }

        // Audit properties
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
