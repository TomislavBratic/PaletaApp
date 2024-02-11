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

        public async Task<List<Address>> AddListAddressesAsync(List<Address> request)
        {
            try
            { 
                foreach (var address in request)
                {
                    var existingAddress = await dbContext.Adresses.FirstOrDefaultAsync(o => o.Id == address.Id);

                    if (existingAddress != null)
                    { dbContext.Entry(existingAddress).CurrentValues.SetValues(address); }
                    else
                    {
                        dbContext.Adresses.Add(address);
                    }
                }

                await dbContext.SaveChangesAsync();

                return request;
            }

            catch (DbUpdateException ex)
            {
                return request;
            }
        }

        public async Task<List<Email>> AddListEmailAddressesAsync(List<Email> request)
        {
            try
            {
                foreach (var email in request)
                {
                    var existingEmail = await dbContext.Emails.FirstOrDefaultAsync(o => o.Id == email.Id);

                    if (existingEmail != null)
                    { dbContext.Entry(existingEmail).CurrentValues.SetValues(email); }
                    else
                    { dbContext.Emails.Add(email); }
                }
                await dbContext.SaveChangesAsync();

                return request;
            }

            catch (DbUpdateException ex)
            {
                return request;
            }
        }

        public async Task<Person> AddPersonNameAsync(Person person)
        {
            await dbContext.People.AddAsync(person);
            await dbContext.SaveChangesAsync();

            return person;
        }
    }
}
