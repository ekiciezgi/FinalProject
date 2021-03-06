﻿
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Aoutofac.Caching;
using Core.Aspects.Aoutofac.Performance;
using Core.Aspects.Aoutofac.Transaction;
using Core.Aspects.Aoutofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManeger : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
     
        public ProductManeger(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<Product>>GetAll()
        {
            //iş kodları 
          if(DateTime.Now.Hour==2)
         {
            return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
          }


         return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
       }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetailDtos());
        }

        public IDataResult<List<Product>>GetALLByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>> ( _productDal.GetAll(p=>p.CategoryId==id));
        }

       

       

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List< Product >>(_productDal.GetAll(p=>p.UnitPrice>=min&&p.UnitPrice<=max));

        }

        //[SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
           IResult result= BusinessRules.Run(ChechIfProductExists(product.ProductName),
                ChechIfProductCountOfCategoryCorrect(product.CategoryId),CheckIfCategoryLimitExceded());

            if (result != null)
            {
                return result;
            }

         
             _productDal.Add(product);

            return new SuccessResult(Messages.ProductAddes);
            
        }

        
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }
        //validation 
        //iş kodları 

        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        private IResult ChechIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result > 10)
              
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult ChechIfProductExists(string name)
        {
           var  result= _productDal.GetAll(p => p.ProductName == name).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);

            }
            return new SuccessResult();
        }
        private IResult CheckIfCategoryLimitExceded()

        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            _productDal.Update(product);
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
