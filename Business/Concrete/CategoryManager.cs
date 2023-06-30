using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            //Is kodlari
            return _categoryDal.GetAll();
        }

        //Select * from Categories where CategoryId=3
        public Category GetById(int id)
        {
            return _categoryDal.Get(c => c.CategoryId == id);
        }
    }
}