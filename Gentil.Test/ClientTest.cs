using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gentil.WebAPI.Controllers;
using Gentil.Service.Services;
using Gentil.Test.Repositories;

namespace Gentil.Test
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void TestGetClientByID()
        {
            var controller = GetMokedClientController();

            var id = new Guid("a0ece5db-cd14-4f21-812f-966633e7be86");

            var client = controller.GetClientByID(id);
            Assert.IsNotNull(client);
            Assert.AreEqual(id, client.ID);
            Assert.AreEqual("Britney", client.Name);
        }

        [TestMethod]
        public void TestGetClientByName()
        {
            var controller = GetMokedClientController();

            var name = "Manning";

            var client = controller.GetClientByName(name);
            Assert.IsNotNull(client);
            Assert.AreEqual(new Guid("e8fd159b-57c4-4d36-9bd7-a59ca13057bb"), client.ID);
            Assert.AreEqual("Manning", client.Name);
        }

        [TestMethod]
        public void TestGetPoliciesByClientName()
        {
            var controller = GetMokedClientController();

            var name = "Britney";

            var policies = controller.GetPoliciesByClientName(name);

            Assert.IsNotNull(policies);
            Assert.AreEqual(102, policies.Length);
        }

        public ClientController GetMokedClientController()
        {
            var mockedClients = MockHelper.GetMockedClients();
            var mockedPolicies = MockHelper.GetMockedPolicies();

            var clientRepository = new ClientTestRepository(mockedClients);
            var policyRepository = new PolicyTestRepository(mockedPolicies);

            var clientService = new ClientService(clientRepository, policyRepository);
            var policyService = new PolicyService(policyRepository, clientRepository);

            return new ClientController(clientService, policyService);
        }

    }
}