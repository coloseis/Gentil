using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gentil.WebAPI.Controllers;
using Gentil.Service.Services;
using Gentil.Test.Repositories;

namespace Gentil.Test
{
    [TestClass]
    public class PolicyTest
    {
        [TestMethod]
        public void TestGetClientByPolicyId()
        {
            var controller = GetMokedPolicyController();

            var id = new Guid("64cceef9-3a01-49ae-a23b-3761b604800b");

            var client = controller.GetClientByPolicyId(id);
            Assert.IsNotNull(client);
            Assert.AreEqual(new Guid("e8fd159b-57c4-4d36-9bd7-a59ca13057bb"), client.ID);
            Assert.AreEqual("Manning", client.Name);
        }

        public PolicyController GetMokedPolicyController()
        {
            var mockedClients = MockHelper.GetMockedClients();
            var mockedPolicies = MockHelper.GetMockedPolicies();

            var clientRepository = new ClientTestRepository(mockedClients);
            var policyRepository = new PolicyTestRepository(mockedPolicies);
            var service = new PolicyService(policyRepository, clientRepository);
            return new PolicyController(service);
        }

    }
}

