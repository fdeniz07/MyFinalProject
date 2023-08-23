using System.Text;

namespace Core.Utilities.Security.Hashing
{
    //Bu class'in amaci kullanicinin verdigi sifreyi Hashleyip Saltlamaktir ya da sifreyi dogrulamaktir.
    public class HashingHelper
    {
        //Deger türlerini referans olarak metoda gecmek icin ref ve out keywordlari kullanilir. Her ikisi de ayni islemi yapar.
        //ref ile kullanımda değişkene başlangıç değerinin verilmesi gerekirken
        //out anahtar kelimesi ile kullanımda başlangıç değerinin verilmesine gerek yoktur.
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true; 
            }
        }
    }
}
