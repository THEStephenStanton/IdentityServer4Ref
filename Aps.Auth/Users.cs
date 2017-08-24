using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aps.Auth
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
                    Username = "Rick",
                    Password = "wubbalubba"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "Morty",
                    Password = "uhhh"
                }
            };
        }
    }
}
