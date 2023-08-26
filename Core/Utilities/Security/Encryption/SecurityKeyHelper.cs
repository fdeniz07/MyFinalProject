using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    //Bu class'in amaci appSettings.json dosyasina girilen SecurityKey'in projedeki ilgili yapida olusturulmasidir.
    //Ayrica SynmetricSecutiryKey ve AsyncmetricSecurityKey nedir? arastirilabilir
    public class SecurityKeyHelper
    {
        //Yeni yazim
        public static SecurityKey CreateSecurityKey(string securityKey) => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

        //Eski yazim
        //public static SecurityKey CreateSecurityKey(string securityKey)
        //{
        //    return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        //}
    }
}
