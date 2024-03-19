using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaletaApp.DataAccess;
using PaletaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaletaApp.Controllers
{
    public class BuggyController : BaseController
    {
        private readonly UserContext _dbcontext;
        public BuggyController(UserContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }

     [Authorize]
     [HttpGet("auth")]
     public ActionResult<string> GetSecret()
        {
            return "secret key";
        }

    [HttpGet("not-found")]
     public ActionResult<User> GetNotFound()
        {
            var thing = _dbcontext.Users.Find(-1);

            if (thing == null) return NotFound();

            return thing;
         }
    [HttpGet("server-error")]
     public ActionResult<string> GetServerError()
        {
            var thing = _dbcontext.Users.Find(-1);

            var thingToReturn = thing.ToString();

            return thingToReturn;

        }
    [HttpGet("bad-request")]
     public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This is a not a good request");
        }

    }
}
