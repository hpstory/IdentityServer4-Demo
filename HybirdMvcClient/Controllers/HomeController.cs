﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HybirdMvcClient.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Globalization;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using System.Net;

namespace HybirdMvcClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authorize(Roles = "admin,guest")]
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            if (disco.IsError)
            {
                throw new Exception(disco.Error);
            }

            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            client.SetBearerToken(accessToken);

            var response = await client.GetAsync("https://localhost:6001/identity");
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await RenewTokenAsync();
                    return RedirectToAction();
                }

                throw new Exception(response.ReasonPhrase);
            }

            var content = await response.Content.ReadAsStringAsync();
            return View("Index", content);
        }
        [Authorize(Policy = "sb")]
        public async Task<IActionResult> Privacy()
        {
            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            var idToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);
            var refreshToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);
            // var authorizationCode = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.Code);
            ViewData["accessToken"] = accessToken;
            ViewData["idToken"] = idToken;
            ViewData["refreshToken"] = refreshToken;
            return View();
        }

        public async Task Logout()
        {
            // revoke token only for reference
            //var client = new HttpClient();
            //var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            //if (disco.IsError)
            //{
            //    throw new Exception(disco.Error);
            //}

            //var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            //if (!string.IsNullOrWhiteSpace(accessToken))
            //{
            //    var revokeAccessTokenResponse = await client.RevokeTokenAsync(new TokenRevocationRequest
            //    {
            //        Address = disco.RevocationEndpoint,
            //        ClientId = "hybrid client",
            //        ClientSecret = "hybrid secret",
            //        Token = accessToken
            //    });

            //    if (revokeAccessTokenResponse.IsError)
            //    {
            //        throw new Exception("Access Token Revocation Failed: " + revokeAccessTokenResponse.Error);
            //    }
            //}

            //var refreshToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);
            //if (!string.IsNullOrWhiteSpace(refreshToken))
            //{
            //    var revokeRefreshTokenResponse = await client.RevokeTokenAsync(new TokenRevocationRequest
            //    {
            //        Address = disco.RevocationEndpoint,
            //        ClientId = "hybrid client",
            //        ClientSecret = "hybrid secret",
            //        Token = refreshToken
            //    });

            //    if (revokeRefreshTokenResponse.IsError)
            //    {
            //        throw new Exception("Refresh Token Revocation Failed: " + revokeRefreshTokenResponse.Error);
            //    }
            //}
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }

        private async Task<string> RenewTokenAsync()
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            if (disco.IsError)
            {
                throw new Exception(disco.Error);
            }
            var refreshToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);
            var tokenResponse = await client.RequestRefreshTokenAsync(new RefreshTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "mvc",
                ClientSecret = "secret",
                Scope = "scope1 openid profile email phone address",
                GrantType = OpenIdConnectGrantTypes.RefreshToken,
                RefreshToken = refreshToken
            });
            if (tokenResponse.IsError)
            {
                throw new Exception(tokenResponse.Error);
            }
            else
            {
                var expiresAt = DateTime.UtcNow + TimeSpan.FromSeconds(tokenResponse.ExpiresIn);
                var tokens = new[]
                {
                    new AuthenticationToken
                    {
                        Name = OpenIdConnectParameterNames.IdToken,
                        Value = tokenResponse.IdentityToken
                    },
                    new AuthenticationToken
                    {
                        Name = OpenIdConnectParameterNames.AccessToken,
                        Value = tokenResponse.AccessToken
                    },
                    new AuthenticationToken
                    {
                        Name = OpenIdConnectParameterNames.RefreshToken,
                        Value = tokenResponse.RefreshToken
                    },
                    new AuthenticationToken
                    {
                        Name = "expires_at",
                        Value = expiresAt.ToString("o", CultureInfo.InvariantCulture)
                    },
                };

                // 获取身份认证结果
                var currentAuthenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                // 更新token
                currentAuthenticateResult.Properties.StoreTokens(tokens);
                // 登陆
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    currentAuthenticateResult.Principal,
                    currentAuthenticateResult.Properties);

                return tokenResponse.AccessToken;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
