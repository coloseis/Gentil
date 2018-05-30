using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Gentil.Service.Models;
using Gentil.Service.Services.Contracts;
using Gentil.WebAPI.Autorize;

namespace Gentil.WebAPI.Controllers
{
    [RoutePrefix("api/policy")]
    public class PolicyController : ApiController
    {
        private readonly IPolicyService _policyService;

        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        [HttpGet]
        [Route("{id:guid}/client")]
        [TokenFilter(Roles = "admin")]
        public ClientDTO GetClientByPolicyId(Guid id)
        {
            return _policyService.GetClientByPolicyId(id);
        }
    }
}