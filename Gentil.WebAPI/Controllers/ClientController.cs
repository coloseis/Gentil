using System;
using System.Collections.Generic;
using System.Web.Http;
using Gentil.Service.Models;
using Gentil.Service.Services.Contracts;
using Gentil.WebAPI.Autorize;

namespace Gentil.WebAPI.Controllers
{
    [RoutePrefix("api/client")]
    public class ClientController : ApiController
    {
        private readonly IClientService _clientService;
        private readonly IPolicyService _policyService;

        public ClientController(IClientService clientService, IPolicyService policyService)
        {
            _clientService = clientService;
            _policyService = policyService;
        }

        [HttpGet]
        [TokenFilter]
        public ClientDTO[] GetClients()
        {
            return _clientService.GetClients();
        }

        [HttpGet]
        [Route("{id:guid}")]
        [TokenFilter(Roles = "admin,user")]
        public ClientDTO GetClientByID(Guid id)
        {
            return _clientService.GetClientByID(id);
        }

        [HttpGet]
        [Route("{name}")]
        [TokenFilter(Roles = "admin,user")]
        public ClientDTO GetClientByName(string name)
        {
            return _clientService.GetClientByName(name);
        }

        [HttpGet]
        [Route("{name}/policies")]
        [TokenFilter(Roles = "admin")]
        public PolicyDTO[] GetPoliciesByClientName(string name)
        {
            return _clientService.GetPoliciesByClientName(name);
        }

        [HttpGet]
        [Route("{id:guid}/policies")]
        [TokenFilter]
        public PolicyDTO[] GetPoliciesByClientID(Guid id)
        {
            return _policyService.GetPoliciesByClientId(id);
        }
    }
}