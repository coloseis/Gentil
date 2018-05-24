using System;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using Gentil.Service.Services.Contracts;
using Gentil.WebAPI.Autorize;
using Gentil.WebAPI.Log.Attribute;

namespace Gentil.WebAPI.Controllers
{
    public class LoginController : ApiController
    {
        private readonly IUsersService _usersService;

        public LoginController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [Route("login")]
        [HttpGet]
        [AllowAnonymous]
        [ResponseType(typeof(string))]
        public IHttpActionResult LogIn(string user, string password)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
                return BadRequest("Inicio de sesión inválido.");

            password = Encoding.UTF8.GetString(Convert.FromBase64String(password));
            var usuario = _usersService.Validate(user, password);
            if (usuario != null)
            {
                var jwt = new JsonWebToken();
                var token = jwt.Encode(usuario);
                return Ok(token);
            }
            return Unauthorized();
        }
    }
}