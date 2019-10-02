using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Login.Model;
using System.Linq;

namespace WebApi.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
    

        public UsersController()
        {
           
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userDto)
        {
            var user = UsersFake().Where(x => x.CPF == userDto.CPF && x.Password == userDto.Password ).FirstOrDefault();

            if (user != null)
            {

                return Ok(new
                {
                    Id = user.IDUser,
                    Username = user.Name,
                    Token = "KSAJDOASDKOANSKODNASKODNKOASNDKLASNDO"
                });
            }
            else
            {
                return NotFound();
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]User userDto)
        {
            return Ok();        
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {          
            return Ok(UsersFake());
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetById(int id)
        {         
            return Ok(UsersFake().Where(x=> x.IDUser==id));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]User userDto)
        {
            return Ok();
           
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {           
            return Ok();
        }


        public static List<User> UsersFake()
        {
            List<User> user = new List<User>();

            var user1 = new User()
            {
                IDUser = 1,
                CPF="12112121212",
                Name = "Vinicius",
                Login="vinicius01",
                Password ="123"
            };
            var user2 = new User()
            {
                IDUser = 2,
                CPF = "12112121212",
                Name = "Marco Mendes",
                Login ="marco01",
                Password = "123"
            };
            var user3 = new User()
            {
                IDUser = 3,
                CPF = "12112121212",
                Name = "João",
                Login="joao1",
                Password = "123"
            };
            var user4 = new User()
            {
                IDUser = 4,
                CPF = "12112121212",
                Name = "Maria",
                Login ="maria01",
                Password = "123"
            };

            user.Add(user1);
            user.Add(user2);
            user.Add(user3);
            user.Add(user4);

            return user;
        }
    }
}
