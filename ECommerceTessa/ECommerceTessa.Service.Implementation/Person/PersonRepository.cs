using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Domain.IRepository;
using ECommerceTessa.Infraestructure;
using ECommerceTessa.Service.Interface.Person;
using ECommerceTessa.Service.Interface.Person.DTOs;

namespace ECommerceTessa.Service.Implementation.Person
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IRepository<Domain.Entities.Person> _personRepository;

        public PersonRepository(IRepository<Domain.Entities.Person> personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task Create(PersonDto dto)
        {
            var person = new Domain.Entities.Person
            {
                Name = dto.Name,
                LastName = dto.LastName,
                Dni = dto.Dni,
                Cuil = dto.Cuil,
                CellPhone = dto.CellPhone,
                BirthDate = dto.BirthDate,
                ErasedState = false
            };

            await _personRepository.Create(person);
        }

        public async Task Delete(PersonDto dto)
        {
            var person = await _personRepository.GetById(dto.Id);

            if (person != null)
            {
                var delete = await _personRepository.GetById(person.Id);

                if (delete.ErasedState)
                {
                    delete.ErasedState = false;
                    await _personRepository.Update(delete);
                }
                else
                {
                    delete.ErasedState = true;
                    await _personRepository.Update(delete);
                }
            }
            else
            {
                throw new Exception("This Person not exist");
            }
        }

        public async Task Update(PersonDto dto)
        {
            using (var context = new DataContext())
            {
                var updatePerson = context.Persons.FirstOrDefault(x => x.Id == dto.Id);

                if (updatePerson == null)
                {
                    throw new Exception("The Person to modify was not found");
                }
                else
                {
                    if (updatePerson.ErasedState)
                    {
                        throw new Exception("The Person is eliminated");
                    }

                    updatePerson.Name = dto.Name;
                    updatePerson.LastName = dto.LastName;
                    updatePerson.Dni = dto.Dni;
                    updatePerson.Cuil = dto.Cuil;
                    updatePerson.CellPhone = dto.CellPhone;
                    updatePerson.BirthDate = dto.BirthDate;

                    await _personRepository.Update(updatePerson);
                }
            }
        }
    }
}
