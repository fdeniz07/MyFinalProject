using System;

namespace Core.Utilities.Security.JWT
{
    //Not: Bu classin amaci JWT ile Authenticate olacak kullanici icin bir AccessToken üretecektir.
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

        public AccessToken()
        {
            Token = string.Empty;
        }

        public AccessToken(string token, DateTime expiration)
        {
            Token = token;
            Expiration = expiration;
        }
    }
}
