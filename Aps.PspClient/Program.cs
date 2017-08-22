using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aps.PspClient
{
    class Program
    {
        private const string identityServer = "http://localhost:5000";
        private const string apsApi = "http://localhost:5001";

        private const string clientId = "pawnShopPlanet";
        private const string secret = "secret";
        private const string scope = "apsApi";

        static void Main(string[] args)
        {
            DiscoveryResponse disco = GetDiscoveryClient().Result;

            string accessToken = GetAccessToken(disco).Result;

            CallApi(accessToken);
        }

        private static async Task<DiscoveryResponse> GetDiscoveryClient()
        {
            return await DiscoveryClient.GetAsync(identityServer);
        }

        private static async Task<string> GetAccessToken(DiscoveryResponse disco)
        {
            var tokenClient = new TokenClient(disco.TokenEndpoint, clientId, secret);
            TokenResponse tokenResponse = await tokenClient.RequestClientCredentialsAsync(scope);

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
            }

            Console.WriteLine($"Token:\n{ tokenResponse.Json }\n\n");

            return tokenResponse.AccessToken;
        }

        private static async void CallApi(string accessToken)
        {
            var client = new HttpClient();
            client.SetBearerToken(accessToken);

            var response = await client.GetAsync($"{ apsApi }/api/identity");

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }
        }
    }
}
