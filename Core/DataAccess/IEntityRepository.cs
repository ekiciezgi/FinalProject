
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Abstract

{


    //class:refarans tip
    //new():newlwnwbilir olmalı 
    
    //ıentity:ıentity olabilir veya ıentity implemente eden bir nesne olabilir.
   public  interface IEntityRepository<T>where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>>filter=null);
        T Get(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
      
    }
}
