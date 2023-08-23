using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Hashing
{
    //JWT de kullanilacak key'in dogrulanmasi
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
