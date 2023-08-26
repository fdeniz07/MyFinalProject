using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    //Bu class'in amaci kullanicinin verdigi sifreyi Hashleyip Saltlamaktir ya da sifreyi dogrulamaktir.
    public static class HashingHelper
    {
        //Deger türlerini referans olarak metoda gecmek icin ref ve out keywordlari kullanilir. Her ikisi de ayni islemi yapar.
        //ref ile kullanımda değişkene başlangıç değerinin verilmesi gerekirken
        //out anahtar kelimesi ile kullanımda başlangıç değerinin verilmesine gerek yoktur.
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //Yeni yazim
            using HMACSHA512 hmac = new();

            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            //Eski yazim
            //using (var hmac = new System.Security.Cryptography.HMACSHA512())
            //{
            //    passwordSalt = hmac.Key;
            //    passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            //}
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            //Yeni Yazim
            using HMACSHA512 hmac = new(passwordSalt);

            byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(passwordHash);


            //Eski yazim
            //using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            //{
            //    var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            //    for (int i = 0; i < computedHash.Length; i++)
            //    {
            //        if (computedHash[i] != passwordHash[i])
            //        {
            //            return false;
            //        }
            //    }
            //    return true; 
            //}
        }
    }
}
