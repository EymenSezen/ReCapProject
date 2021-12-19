using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey) //aldığımız keylerin byte olması için(JSON servicelar anlasın diye)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));//simetrik anahtar oluşturuyoruz
        }

    }
}
