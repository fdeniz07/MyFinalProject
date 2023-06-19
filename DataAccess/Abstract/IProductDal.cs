using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IProductDal :IEntityRepository<Product> //Interface'ler default da public degildir ama metotlari public'tir!
    {
        //List<Product> GetAll();
        //void Add(Product product);
        //void Update(Product product);
        //void Delete(Product product);
        //List<Product> GetAllByCategory(int categoryId);
    }
}
