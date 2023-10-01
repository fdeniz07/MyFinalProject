using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Business;
using Core.Aspects.Autofac.Performance;
using System.Threading;
using Business.CCS;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        //[SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            #region Attribute Öncesi Kod Yapisi

            #region Kötü kodun iyilestirilip, CrossCuttingConcerns olarak ele alinmasi

            //var context = new ValidationContext<Product>(product);
            //ProductValidator productValidator = new ProductValidator();

            //var result = productValidator.Validate(context);
            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}

            //Fluent Validation öncesi validasyon islemi

            //if (product.ProductName.Length < 2)
            //{
            //    //magic strings
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //}

            #endregion

            // ValidationTool.Validate(new ProductValidator(), product);
            //Loglama
            //cacheremove
            //performance
            //transaction
            //yetkilendirme

            #endregion

            IResult result = BusinessRules.Run(CheckIfProductNameExist(product.ProductName),
                CheckIfProductCountOfCategoryCorrect(product.CategoryId),CheckIfCategoryLimitExceded());

            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);

            #region Before Code Review

            //if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success) //Burada && ile gidilebilir ama kod okunurlugu azalir
            //{
            //    if (CheckIfProductNameExist(product.ProductName).Success)
            //    {
            //        _productDal.Add(product);
            //        return new SuccessResult(Messages.ProductAdded);
            //    }
            //}
            //return new ErrorResult();

            #endregion
        }

        private IResult CheckIfProductNameExist(string productName) //Ayni isimde ürün eklenemez
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }

            return new SuccessResult();
        }
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId) //Bir kategoride en fazla 15 ürün olabilir
        {
            //Select count(*) from products where categoryId=1
            var criterion = 15;
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result > criterion)
            {
                {
                    return new ErrorResult(string.Format(Messages.ProductCountOfCategoryError, criterion));
                }
            }

            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded() //Bir kategoriye 15 den fazla ürün eklenemez
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

        //Claim
        //[SecuredOperation("product.add,admin")]
        [SecuredOperation("user")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)
            {
                if (CheckIfProductNameExist(product.ProductName).Success)
                {
                    _productDal.Update(product);
                    return new SuccessResult(Messages.ProductAdded);
                }
            }

            return new SuccessResult();
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(int productId)
        {
            throw new NotImplementedException();
        }

        [PerformanceAspect(5)] // islem 5sn den fazla sürerse outputtan takip edebilecegiz.
        public IDataResult<List<Product>> GetList()
        {
            //Is Kodlari
            //Yetkisi var mi?

            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            Thread.Sleep(5000); //uygulamayi 5sn ligine durdurup, performance aspect'ini test ediyoruz.
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        [SecuredOperation("Product.List,Admin")]
        //[LogAspect(typeof(FileLogger))]
        [CacheAspect(duration: 10)]
        public IDataResult<List<Product>> GetListByCategory(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(
                _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [TransactionScopeAspect]
        public IResult AddTransactionanTest(Product product)
        {
            _productDal.Update(product);
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductUptaded);
        }
    }
}