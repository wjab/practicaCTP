using AutoMapper;
using Inyection_dependency_example.DTOs;
using Inyection_dependency_example.Entidades;
using Inyection_dependency_example.Interface;

namespace Inyection_dependency_example.Implementation
{
    public class PersonAPI : IPerson
    {
        // En un caso real se encontraria una referencia de BD y se le instanciaria con una dependencia
        private Person? person;
        private IMapper mapper;

        public PersonAPI(IMapper mapper) 
        { 
            this.mapper = mapper;
        }

        public PersonDTO? Add(PersonDTO person)
        {
            if(this.person == null)
            {
                this.person = mapper.Map<Person>(person);
                this.person.CreationDate = DateTime.Now;
                return mapper.Map<PersonDTO>(this.person);
            }
            return null;
        }

        public bool Delete()
        {
            this.person = null;
            return true;
        }

        public PersonDTO? Get()
        {
            if (person == null) 
            {
                return null;
            }
            return mapper.Map<PersonDTO>(this.person);
        }

        public PersonDTO? Update(PersonDTO person)
        {
            if (person == null) 
            {
                return null;
            }
            this.person!.Name = person.Name;
            this.person!.Surname = person.Surname;
            this.person!.BirthDay = person.BirthDay;
            this.person!.UpdateDate = DateTime.Now;
            return mapper.Map<PersonDTO>(this.person);
        }
    }
}
