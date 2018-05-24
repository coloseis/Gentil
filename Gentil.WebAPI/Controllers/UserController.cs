using System;
using System.Web.Http;
using Gentil.Service.Models;
using Gentil.Service.Services.Contracts;
using Gentil.WebAPI.Autorize;

namespace Gentil.WebAPI.Controllers
{
    [TokenFilter(Roles = "1")]
    public class UsersController : ApiController
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        
        // GET: api/Users
        
        [HttpGet]
        public UserDTO[] GetUsers()
        {
            return _usersService.GetUsers();
        }

        // GET: api/Users/5
        [HttpGet]
        public UserDTO GetUser(int id)
        {
            return _usersService.GetUserByID(id);
        }

        // POST: api/Users
        [HttpPost]
        public IHttpActionResult Post([FromBody] UserDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _usersService.InsertUser(value);

            return Ok();
        }

        // PUT: api/User/5
        [HttpPut]
        public IHttpActionResult Put([FromBody] UserDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _usersService.UpdateUser(value);

            return Ok();
        }

        // DELETE: api/User/5
        [HttpDelete]
        public void Delete(int id)
        {
            _usersService.DeleteUser(id);
        }
    }
}