using AutoMapper;
using Inyection_dependency_example.DB;
using Inyection_dependency_example.DTOs;
using Inyection_dependency_example.Entidades;

namespace Inyection_dependency_example.Utils
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<BookShelf, BookShelfDTO>().ReverseMap();

            CreateMap<BookShelfDB, BookShelfDTO>().ReverseMap();


            CreateMap<BookStoreDB, BookStoreDTO>().ReverseMap();
        }
    }

}
