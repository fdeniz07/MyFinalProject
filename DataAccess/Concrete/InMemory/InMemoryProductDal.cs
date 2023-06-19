 using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; //Global Degisken tanimlamalari hep "_" cizgi ile baslar

        public InMemoryProductDal()
        {
            //Oracle,SQL Server,Postgres, MongiDb
            _products = new List<Product> {
                new Product{ProductId=1, ProductName="Bardak",CategoryId=1,UnitPrice=15, UnitsInStock=15},
                new Product{ProductId=2, ProductName="Kamera",CategoryId=1,UnitPrice=500, UnitsInStock=3},
                new Product{ProductId=3, ProductName="Telefon",CategoryId=2,UnitPrice=1500, UnitsInStock=2},
                new Product{ProductId=4, ProductName="Klavye",CategoryId=2,UnitPrice=150, UnitsInStock=65},
                new Product{ProductId=5, ProductName="Fare",CategoryId=2,UnitPrice=85, UnitsInStock=1},
            };
        }

        public void Add(Product category)
        {
            _products.Add(category);
        }

        public void Delete(Product category)
        {
            // _products.Remove(category); //Referans tipler kesinlikle bu sekilde silinemez!

            #region LINQ'suz yazma
            /*
            Category categoryToDelete = null;
            foreach (var p in _products)
            {
                if (category.ProductId == p.ProductId)
                {
                    categoryToDelete = p;
                }
            }
            */
            #endregion

            #region LINQ ile yazma 
            //Lambda p=>p.

            Product categoryToDelete = _products.SingleOrDefault(p => p.ProductId == category.ProductId);
            _products.Remove(categoryToDelete);

            #endregion
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product category)
        {
            //Gönderdigim ürün id'sine sahip olan listedeki ürünü bul
            Product categoryToUpdate = _products.SingleOrDefault(p => p.ProductId == category.ProductId);
            categoryToUpdate.ProductName = category.ProductName;
            categoryToUpdate.CategoryId = category.CategoryId;
            categoryToUpdate.UnitPrice = category.UnitPrice;
            category.UnitsInStock = category.UnitsInStock;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
