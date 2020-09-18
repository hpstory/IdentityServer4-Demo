using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static async Task Main()
        {
            var client = new HttpClient();

            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");

            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }

            //var apiTokenResponse = await client.RequestClientCredentialsTokenAsync(
            //    new ClientCredentialsTokenRequest 
            //    {
            //        Address = disco.TokenEndpoint,
            //        ClientId = "client",
            //        ClientSecret = "511536EF-F270-4058-80CA-1C89C192F69A",
            //        Scope = "scope1"
            //    });

            //if (apiTokenResponse.IsError)
            //{
            //    Console.WriteLine(apiTokenResponse.Error);
            //    return;
            //}

            //var apiClient = new HttpClient();

            //apiClient.SetBearerToken(apiTokenResponse.AccessToken);
            //var response = await apiClient.GetAsync("https://localhost:6001/identity");
            //if (!response.IsSuccessStatusCode)
            //{
            //    Console.WriteLine(response.StatusCode);
            //}
            //else
            //{
            //    var content = await response.Content.ReadAsStringAsync();
            //    Console.WriteLine(JArray.Parse(content));
            //}

            var passwordTokenResponse = await client.RequestPasswordTokenAsync(
                new PasswordTokenRequest
                {
                    Address = disco.TokenEndpoint,
                    ClientId = "password",
                    ClientSecret = "511536EF-F270-4058-80CA-1C89C192F69A",
                    Scope = "scope1 openid profile",
                    UserName = "alice",
                    Password = "alice"
                });

            if (passwordTokenResponse.IsError)
            {
                Console.WriteLine(passwordTokenResponse.IsError);
                return;
            }
            var passwordClient = new HttpClient();
            passwordClient.SetBearerToken(passwordTokenResponse.AccessToken);
            var response = await passwordClient.GetAsync(disco.UserInfoEndpoint);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }

            Console.ReadKey();
        }
    }
}
