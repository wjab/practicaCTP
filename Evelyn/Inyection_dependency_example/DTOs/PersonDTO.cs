namespace Inyection_dependency_example.DTOs
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateOnly BirthDay { get; set; }
    }
}
