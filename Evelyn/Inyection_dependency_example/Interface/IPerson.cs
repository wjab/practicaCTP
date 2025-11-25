using Inyection_dependency_example.DTOs;

namespace Inyection_dependency_example.Interface
{
    public interface IPerson
    {
        PersonDTO? Add(PersonDTO person);
        PersonDTO? Update(PersonDTO person);
        bool Delete();
        PersonDTO? Get();
    }
}
