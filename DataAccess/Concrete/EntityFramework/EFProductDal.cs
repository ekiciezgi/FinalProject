
using Core.DataAccess.EntityFramwork;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace DataAccess.Concrete.EntityFramework
{
    public class EFProductDal : EfEntitiyRepositoryBase<Product, NorthwindContext>, IProductDal
    {   //NuGet
        public List<ProductDetailDto> GetProductDetailDtos()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId
                                 ,
                                 ProductName = p.ProductName
                             ,
                                 CategoryName = c.CategoryName
                             ,
                                 UnitsInStok = p.UnitsInStock
                             };
                return result.ToList();
            }
        }

       
    }
}
