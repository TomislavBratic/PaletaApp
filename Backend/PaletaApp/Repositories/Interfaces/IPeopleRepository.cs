using PaletaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaletaApp.Repositories.Interfaces
{
    public interface IPeopleRepository
    {
        Task<Person> AddPersonNameAsync(Person person);
        Task<List<Person>> GetPeopleAsync();
    }
}
