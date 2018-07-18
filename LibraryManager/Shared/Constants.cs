using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public static class Constants
    {
        /// <summary>
        /// SecretKey is readonly field
        /// </summary>
        public static readonly string SecretKey = "iNivDmHLpUA223sqsfhqGbMRdRj1PVkH";

        public static class Strings
        {
            public static class JwtClaimIdentifiers
            {
                public const string Rol = "rol", Id = "id";
            }

            public static class JwtClaims
            {
                public const string ApiAccess = "api_access";
            }
        }
    }
}
