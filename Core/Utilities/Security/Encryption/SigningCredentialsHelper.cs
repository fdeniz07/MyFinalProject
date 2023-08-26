using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    //JWT de kullanilacak key'in dogrulanmasi
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey) =>
            new(securityKey, SecurityAlgorithms.HmacSha512Signature);
    }
}
