using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManeger : IProductService
    {
        IProductDal _productDal;
        public ProductManeger(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IEnumerable<object> GetAllByCategoryId(int v)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Product>>GetAll()
        {
            //iş kodları 
           // if(DateTime.Now.Hour==22)
        // {
         //   return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
          //}


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

       

        public IResult Add(Product product)
        {
            //iş kodları 
            if (product.ProductName.Length<2)
            {

                return new ErrorResult(Messages.ProductNameInvalid);

            }
            _productDal.Add(product);
            
            return new SuccessResult(Messages.ProductAddes);
        }

        public IDataResult< Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId==productId));
        }

        
    }
}
