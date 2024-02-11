
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
        public async Task<IActionResult> CreatePerson(GetPersonRequest request)
        {
            var person = new Person
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
            };

           await peopleRepository.AddPersonNameAsync(person);

           List<Address> addresses = request.Addresses;

            if (addresses == null || !addresses.Any())
            { return BadRequest("empty List address"); }

            else
            {
                await peopleRepository.AddListAddressesAsync(addresses);
            }

            List<Email> emails = request.Emails;

            if (emails == null || !emails.Any())
            { return BadRequest("empty List email"); }

            else
            {
                await peopleRepository.AddListEmailAddressesAsync(emails);
            }

            return Ok();

        }
    }
}
