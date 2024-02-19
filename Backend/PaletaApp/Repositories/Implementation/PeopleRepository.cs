using Microsoft.EntityFrameworkCore;
using PaletaApp.DataAccess;
using PaletaApp.Models;
using PaletaApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaletaApp.Repositories.Implementation
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly PeopleContext dbContext;

        public PeopleRepository(PeopleContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Person> AddPersonNameAsync(Person person)
        {
            await dbContext.People.AddAsync(person);
            await dbContext.SaveChangesAsync();

            return person;
        }

        public async Task<List<Person>> GetPeopleAsync()
        {
            var persons = await dbContext.People.ToListAsync();
            return persons;
        }
    }
}
