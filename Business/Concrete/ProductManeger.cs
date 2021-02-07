using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public List<Product> GetAll()
        {
            //iş kodları 
            return _productDal.GetAll();
        }

        public List<Product> GetALLByCategoryId(int id)
        {
            return _productDal.GetAll(p=>p.CategoryId==id);
        }

       

       

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=>p.UnitPrice>=min&&p.UnitPrice<=max);

        }
    }
}
