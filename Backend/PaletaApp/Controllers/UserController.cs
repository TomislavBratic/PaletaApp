﻿
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
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsers(List<UserDto> request)
        {
           
            foreach(var persons in request)
            {
                var person = new User
                {
                    FirstName = persons.FirstName,
                    LastName = persons.LastName,
                    Email = persons.Email,
                };
                await userRepository.AddUserNameAsync(person);
            }

            return Ok();

        }
        [HttpGet]
        public async Task <List<UserDto>> GetPeople()
        {
          var allPeopleList= await userRepository.GetUsersAsync();
    
            var peopleDTO = allPeopleList.Select(user => new UserDto
            {
                Id = user.Id,
                UserName= user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email= user.Email,
            }).ToList();


            return peopleDTO;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> CreatePerson(UserDto request)
        {
            if (await UserExists(request.UserName)) return BadRequest("User Name is Taken");

                var hmac = new HMACSHA512();

                var person = new User
                {
                    UserName=request.UserName.ToLower(),
                    FirstName = request.FirstName.ToLower(),
                    LastName = request.LastName.ToLower(),
                    Email = request.Email,
                    PasswordHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password)),
                    PasswordSalt=hmac.Key
                };
                await userRepository.AddUserNameAsync(person);

                return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginPerson(LoginDTO request)
        {
            var user = await userRepository.GetUserName(request.UserName);
            if (user == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));

            for (int i=0; i<computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }
           

            return Ok();
        }


        private async Task<bool> UserExists(string UserName)
        {
            return await userRepository.CheckUserName(UserName);
        }

        }

    }

