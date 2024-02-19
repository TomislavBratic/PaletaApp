
using PaletaApp.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaletaApp.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaletaApp.Models;
using Microsoft.EntityFrameworkCore;
using PaletaApp.Repositories.Interfaces;

namespace PaletaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleRepository peopleRepository;

        public PeopleController(IPeopleRepository peopleRepository )
        {
            this.peopleRepository = peopleRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePeople(List<PersonDto> request)
        {
           
            foreach(var persons in request)
            {
                var person = new Person
                {
                    FirstName = persons.FirstName,
                    LastName = persons.LastName,
                    Email = persons.Email,
                };
                await peopleRepository.AddPersonNameAsync(person);
            }

            return Ok();

        }
        [HttpGet]
        public async Task <List<PersonDto>> GetPeople()
        {
          var allPeopleList= await peopleRepository.GetPeopleAsync();
    
            var peopleDTO = allPeopleList.Select(person => new PersonDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email= person.Email,
            }).ToList();


            return peopleDTO;
        }
        
    }
}
