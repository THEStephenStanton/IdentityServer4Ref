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

        private const string ccClientId = "cc.pawnShopPlanet";
        private const string roClientId = "ro.pawnShopPlanet";

        private const string secret = "secret";
        private const string scope = "apsApi";

        private const string userName1 = "Rick";
        private const string password1 = "wubbalubba";
        private const string userName2 = "Morty";
        private const string password2 = "uhhh";


        static void Main(string[] args)
        {
            DiscoveryResponse disco = GetDiscoveryClient().Result;

            //string accessToken = GetAccessTokenViaClientCredentials(disco).Result;
            //string accessToken = GetAccessTokenViaResourceOwner(disco, userName1, password1).Result;
            string accessToken = GetAccessTokenViaResourceOwner(disco, userName2, password2).Result;

            CallApi(accessToken);
        }

        private static async Task<DiscoveryResponse> GetDiscoveryClient()
        {
            return await DiscoveryClient.GetAsync(identityServer);
        }

        private static async Task<string> GetAccessTokenViaClientCredentials(DiscoveryResponse disco)
        {
            var tokenClient = new TokenClient(disco.TokenEndpoint, ccClientId, secret);
            TokenResponse tokenResponse = await tokenClient.RequestClientCredentialsAsync(scope);

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
            }

            Console.WriteLine($"Token:\n{ tokenResponse.Json }\n\n");

            return tokenResponse.AccessToken;
        }

        private static async Task<string> GetAccessTokenViaResourceOwner(DiscoveryResponse disco, string userName, string password)
        {
            var tokenClient = new TokenClient(disco.TokenEndpoint, roClientId, secret);
            TokenResponse tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(userName, password, scope);

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

            var response = client.GetAsync($"{ apsApi }/api/identity").Result;

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
