using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ProductManager productManager = new ProductManager(new InMemoryProductDal());
            ProductManager
                productManager =
                    new ProductManager(new EfProductDal()); //Sadece kullanimdaki teknolojiyi cagirmamiz yeterli

            //Console.WriteLine("{0,35} -- {1,5} -- {2,5}\n", "Product Name", "Price($)", "Stock");
            //foreach (var product in productManager.GetAll())
            //{
            //    Console.WriteLine("{0,35} -- {1,8} -- {2,5}", product.ProductName, product.UnitPrice, product.UnitsInStock);
            //}

            //Console.WriteLine("2 numarali categoriye ait ürün isimleri gelsin\n");
            //foreach (var product in productManager.GetAllByCategoryId(2)) //2 numarali categoriye ait ürün isimleri gelsin
            //{
            //    Console.WriteLine(product.ProductName);
            //}


            //Console.WriteLine("*************************************************\n");

            //Console.WriteLine("Birim fiyati 40 ile 100 arasindakiler gelsin\n");
            //foreach (var product in productManager.GetByUnitPrice(40,100)) //Birim fiyati 40 ile 100 arasindakiler gelsin
            //{
            //    Console.WriteLine(product.ProductName);
            //}

            Console.WriteLine("*************** Personel List *********************");
            PersonelManager personelManager = new PersonelManager(new EfPersonelDal());

            Console.WriteLine("{0,3} {1,10} {2,20}", "Id", "Personel Name", "Personel Surname");
            foreach (var personel in personelManager.GetAll())
            {
                Console.WriteLine("{0,3} {1,10} {2,16}", personel.Id, personel.Name, personel.Surname);
            }
        }
    }
}