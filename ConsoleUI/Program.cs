using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
             GetAllProductTest();

            // GetAllProductByCategoryIdTest(2); //2 numarali categoriye ait ürün isimleri gelsin

            // GetAllPersonelListTest();

            // GetAllCategoryTest();

            // GetAllOrderByShipCityTest();

           // GetAllProductWithCategoryNameTest();
        }

        private static void GetAllProductWithCategoryNameTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetProductDetails();

            if (result.Success)
            {
                Console.WriteLine("{0,35} -- {1,15} -- {2,5} \n", "ProductName", "CategoryName", "Stock");
                foreach (var product in result.Data)
                {
                    Console.WriteLine("{0,35} -- {1,15} -- {2,5}", product.ProductName, product.CategoryName,product.UnitsInStock);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetAllOrderByShipCityTest()
        {
            OrderManager orderManager = new OrderManager(new EfOrderDal());

            Console.WriteLine("*************** Order List *********************");
            foreach (var order in orderManager.GetAll())
            {
                Console.WriteLine(order.ShipCity);
            }
        }

        private static void GetAllCategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            Console.WriteLine("*************** Category List *********************");
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void GetAllPersonelListTest()
        {
            PersonelManager personelManager = new PersonelManager(new EfPersonelDal());

            Console.WriteLine("{0,3} {1,10} {2,20}", "Id", "Personel Name", "Personel Surname");
            foreach (var personel in personelManager.GetAll())
            {
                Console.WriteLine("{0,3} {1,10} {2,16}", personel.Id, personel.Name, personel.Surname);
            }
        }

        private static void GetAllProductTest()
        {
            //ProductManager productManager = new ProductManager(new InMemoryProductDal());
            ProductManager
                productManager =
                    new ProductManager(new EfProductDal()); //Sadece kullanimdaki teknolojiyi cagirmamiz yeterli

            Console.WriteLine("{0,35} -- {1,5} -- {2,5}\n", "Product Name", "Price($)", "Stock");
            foreach (var product in productManager.GetAll().Data)
            {
                Console.WriteLine("{0,35} -- {1,8} -- {2,5}", product.ProductName, product.UnitPrice,
                    product.UnitsInStock);
            }
        }

        private static void GetAllProductByCategoryIdTest(int categoryId)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            Console.WriteLine("{0} numarali categoriye ait ürün isimleri gelsin\n", categoryId);
            foreach (var product in productManager.GetAllByCategoryId(categoryId).Data)
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}