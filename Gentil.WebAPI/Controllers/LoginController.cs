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
        private readonly IClientService _clientService;

        public LoginController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [Route("login")]
        [HttpGet]
        [AllowAnonymous]
        [ResponseType(typeof(string))]
        public IHttpActionResult LogIn(string email)
        {
            if (string.IsNullOrEmpty(email))
                return BadRequest("Inicio de sesión inválido.");

            var client = _clientService.GetClientByEmail(email);
            if (client != null)
            {
                var jwt = new JsonWebToken();
                var token = jwt.Encode(client);
                return Ok(token);
            }
            return Unauthorized();
        }
    }
}