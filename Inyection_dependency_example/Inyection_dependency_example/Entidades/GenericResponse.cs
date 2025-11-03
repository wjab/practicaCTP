using System.Net;

namespace Inyection_dependency_example.Entidades
{
    public class GenericResponse
    {
        public HttpStatusCode HttpStatus { get; set; } = HttpStatusCode.OK;
        public string? Message { get; set; }
        public Object? Response { get; set; }
        public Object? Request { get; set; }
    }
}
