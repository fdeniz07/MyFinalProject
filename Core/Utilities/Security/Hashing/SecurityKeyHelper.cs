using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Hashing
{
    //Bu class'in amaci appSettings.json dosyasina girilen SecurityKey'in projedeki ilgili yapida olusturulmasidir.
    //Ayrica SynmetricSecutiryKey ve AsyncmetricSecurityKey nedir? arastirilabilir
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
