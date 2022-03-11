using System;
using System.Collections.Generic;
using System.Text;

namespace PickUpApp
{
    internal class Constants
    {
        public static readonly string tenantName = "authpaket";
        public static readonly string tenantId = "authpaket.onmicrosoft.com";
        public static readonly string clientId = "1d77a1d9-8399-406d-aebb-26b0440af720";
        public static readonly string signInPolicy = "B2C_1_RegistrierungAnmeldung";
        public static readonly string policyPassword = "B2C_1_PasswordReset";
        public static readonly string IosKeychainSecurityGroups = "com.microsoft.aadb2cauthentication";
        public static readonly string[] Scopes = new string[] { "openid", "offline_access" };
        public static readonly string AuthorityBase = $"https://{tenantName}.b2clogin.com/tfp/{tenantId}/";
        public static readonly string AuthoritySignIn = $"{AuthorityBase}{signInPolicy}";
        public static readonly string AuthorityPasswordReset = $"{AuthorityBase}{policyPassword}";

    }
}
