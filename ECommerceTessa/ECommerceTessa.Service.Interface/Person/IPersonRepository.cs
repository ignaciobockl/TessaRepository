using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Person.DTOs;

namespace ECommerceTessa.Service.Interface.Person
{
    public interface IPersonRepository
    {
        Task Create(PersonDto dto);

        Task Update(PersonDto dto);

        Task Delete(PersonDto dto);
    }
}
