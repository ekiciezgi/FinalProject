using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProudctDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProudctDal()
        {
            _products = new List<Product> {

            new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
             new Product { ProductId = 2, CategoryId = 1, ProductName="kamera", UnitPrice =500, UnitsInStock = 3 },
            new Product { ProductId = 3, CategoryId = 1, ProductName="telefon", UnitPrice = 1500, UnitsInStock = 2 },
            new Product { ProductId = 4, CategoryId = 1, ProductName = "kalvye", UnitPrice = 150, UnitsInStock = 65},
            new Product{ProductId=5,CategoryId=1,ProductName="fare",UnitPrice=85,UnitsInStock=1},
            
        };

      
    }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
           Product productToDelete;
            /*foreach(var p in _products)
            {
                if (product.ProductId == p.ProductId) {
                    productToDelete = p;
                }
            }*/  //alttaki satırla aynı şey 
            productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(productToDelete);


        }

        public Product Get(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
                
                
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return  _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetailDtos()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        { // gönderdiğim ürün ıdsine sahip  olan listedki üürnü bul 
             
           Product productUpDate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productUpDate.ProductName = product.ProductName;
            productUpDate.CategoryId = product.CategoryId;
            productUpDate.UnitPrice = product.UnitPrice;
            productUpDate.UnitsInStock = product.UnitsInStock;
        }

    }
}
