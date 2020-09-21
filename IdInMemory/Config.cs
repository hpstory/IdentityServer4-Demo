// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdInMemory
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Address(),
                new IdentityResources.Phone(),
                new IdentityResource("roles", "role", new List<string>{ JwtClaimTypes.Role }),
                new IdentityResource("locations", "location", new List<string>{ "location" })
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("scope1")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "api1",
                    Scopes = { "scope1" },
                    ApiSecrets = { new Secret("api1 secret".Sha256()) }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // client credentials flow client
                new Client
                {
                    ClientId = "client",
                    ClientName = "Client Credentials Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = 
                    { 
                        "scope1", 
                    }
                },

                new Client
                {
                    ClientId = "password",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },
                    AllowedScopes =
                    {
                        "scope1",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },

                new Client
                {
                    ClientId = "mvc",
                    AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowOfflineAccess = true,
                    // where to redirect to after login
                    RedirectUris = { "https://localhost:6002/signin-oidc" },
                    AccessTokenLifetime = 60,
                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "https://localhost:6002/signout-callback-oidc" },
                    AllowedScopes =
                    {
                        "scope1",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Phone,
                    }
                },

                new Client
                {
                    ClientId = "angular-client",
                    ClientName = "angular SPA",
                    ClientUri = "http://localhost:4200",

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = true,
                    AccessTokenLifetime = 60 * 5,
                    RedirectUris =
                    {
                        "http://localhost:4200/signin-oidc",
                        "http://localhost:4200/redirect-silentrenew"
                    },

                    // /结尾，否则登出后无法正常跳转
                    PostLogoutRedirectUris =
                    {
                        "http://localhost:4200/"
                    },

                    AllowedCorsOrigins =
                    {
                        "http://localhost:4200"
                    },

                    AllowedScopes =
                    {
                        "scope1",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Phone,
                    }
                },

                new Client
                {
                    ClientId = "hybrid client",
                    ClientName = "AspDotNetCoreMVC Hybrid",
                    ClientSecrets =
                    {
                        new Secret("hybrid secret".Sha256())
                    },
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    // 指定使用授权代码的客户端是否必须发送证明密钥                  
                    RequirePkce = false,
                    // 设置token类型，默认jwt
                    // AccessTokenType = AccessTokenType.Reference,
                    RedirectUris =
                    {
                        "https://localhost:6003/signin-oidc"
                    },

                    PostLogoutRedirectUris =
                    {
                        "https://localhost:6003/signout-callback-oidc"
                    },

                    AllowOfflineAccess = true,

                    AlwaysIncludeUserClaimsInIdToken = true,

                    AllowedScopes =
                    {
                        "scope1",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Phone,
                        "roles",
                        "locations"
                    }
                }
            };
    }
}