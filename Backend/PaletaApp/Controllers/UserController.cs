
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
using System.Security.Cryptography;
using System.Text;

namespace PaletaApp.Controllers
{
    
    public class UserController : BaseController
    {
        private readonly IUserRepository peopleRepository;

        public UserController(IUserRepository peopleRepository)
        {
            this.peopleRepository = peopleRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePeople(List<UserDto> request)
        {
           
            foreach(var persons in request)
            {
                var person = new User
                {
                    FirstName = persons.FirstName,
                    LastName = persons.LastName,
                    Email = persons.Email,
                };
                await peopleRepository.AddUserNameAsync(person);
            }

            return Ok();

        }
        [HttpGet]
        public async Task <List<UserDto>> GetPeople()
        {
          var allPeopleList= await peopleRepository.GetUsersAsync();
    
            var peopleDTO = allPeopleList.Select(person => new UserDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email= person.Email,
            }).ToList();


            return peopleDTO;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> CreatePerson(UserDto request)
        {
            if (await PersonExists(request.FirstName, request.LastName)) return BadRequest("User Name is Taken");

                var hmac = new HMACSHA512();

                var person = new User
                {
                    FirstName = request.FirstName.ToLower(),
                    LastName = request.LastName.ToLower(),
                    Email = request.Email,
                    PasswordHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password)),
                    PasswordSalt=hmac.Key
                };
                await peopleRepository.AddUserNameAsync(person);

                return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginPerson(UserDto request)
        {
           

            return Ok();
        }


        private async Task<bool> PersonExists(string FirstName,string LastName)
        {
            return await peopleRepository.CheckUserName(FirstName, LastName);
        }

        }

    }

