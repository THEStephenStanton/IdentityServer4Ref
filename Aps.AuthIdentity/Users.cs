using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aps.AuthIdentity
{
    public static class Users
    {
        public static List<TestUser> Get()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "rick",
                    Password = "wubbalubba",
                    Claims = new []
                    {
                        new Claim("name", "Rick Sanchez"),
                        new Claim("website", "http://rickandmorty.wikia.com/wiki/Rick_Sanchez")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "morty",
                    Password = "uhhh",
                    Claims = new []
                    {
                        new Claim("name", "Morty Smith"),
                        new Claim("website", "http://rickandmorty.wikia.com/wiki/Morty_Smith")
                    }
                }
            };
        }
    }
}
