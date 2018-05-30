using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gentil.Business.Models;
using Gentil.Test.Models;
using RestSharp;

namespace Gentil.Test
{
    public static class MockHelper
    {
        public static IEnumerable<Client> GetMockedClients()
        {
            IRestClient restClient = new RestClient("http://www.mocky.io/v2/5808862710000087232b75ac");
            IRestRequest request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            var data = restClient.Execute<ClientsMock>(request).Data;

            return data.Clients;
        }

        public static IEnumerable<Policy> GetMockedPolicies()
        {
            IRestClient restClient = new RestClient("http://www.mocky.io/v2/580891a4100000e8242b75c5");
            IRestRequest request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            var data = restClient.Execute<PoliciesMock>(request).Data;

            return data.Policies;
        }
    }
}
