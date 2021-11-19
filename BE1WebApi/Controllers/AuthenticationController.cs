using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BE1WebApi;
using BE1WebApi.Models;
using Newtonsoft.Json;

namespace BE1WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly SqlContext _context;

        public AuthenticationController(SqlContext context)
        {
            _context = context;
        }


        [HttpPost("SignIn")]
        public async Task<ActionResult<dynamic>> SignIn(LogIn model)
        {
            var user = await _context.Users.Where(x => x.Email == model.Email).FirstOrDefaultAsync();

            if(user != null)
            {
                if(user.Password == model.Password)
                {
                    return new OkObjectResult(JsonConvert.SerializeObject(new { userId = user.Id, sessionId = Guid.NewGuid().ToString() }));
                }

                return new BadRequestObjectResult(JsonConvert.SerializeObject(new { message = "Incorrect email or password" }));
            }

            return new BadRequestObjectResult(JsonConvert.SerializeObject(new { message = "Incorrect email or password" }));

        }

        [HttpPost("SignUp")]
        public async Task<ActionResult<dynamic>> SignUp(CreateUserModel model)
        {
            var _user = await _context.Users.Where(x => x.Email == model.Email).FirstOrDefaultAsync();

            if (_user != null)
            {
                var user = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                    PhoneNumber = model.PhoneNumber,
                    AddressLine = model.AddressLine,
                    Zipcode = model.Zipcode,
                    City = model.City
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return new OkResult();
            }

            return new BadRequestObjectResult(JsonConvert.SerializeObject(new { message = "A user with the same email address already exists." }));

        }
    }
}
