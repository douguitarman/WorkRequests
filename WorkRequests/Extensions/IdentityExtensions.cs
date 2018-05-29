using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace WorkRequests.Extensions
{
    public static class IdentityExtensions
    {
        /// <summary>
        /// GetFullName
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string GetFullName(this IIdentity identity)
        {
            var firstName = ((ClaimsIdentity)identity).FindFirst("FirstName");

            var lastName = ((ClaimsIdentity)identity).FindFirst("LastName");

            return (firstName != null && lastName != null) ? firstName.Value + " " + lastName.Value : string.Empty;

            //return (claim != null) ? claim.Value : string.Empty;
        }
    }
}