using System;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aps.AuthIdentity
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "cc.pawnShopPlanet",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "apsApi" }
                },
                new Client
                {
                    ClientId = "ro.pawnShopPlanet",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "apsApi" }
                },
                // OpenID Connect implicit flow client (MVC)
                new Client
                {
                    ClientId = "mvc.pawnShopPlanet",
                    ClientName = "Pawn Shop Planet MVC",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    RequireConsent = false,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // where to redirect to after login
                    RedirectUris = { "http://localhost:5002/signin-oidc" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "apsApi"
                    },
                    AllowOfflineAccess = true
                }
            };
        }
    }
}
