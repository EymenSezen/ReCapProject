using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand,CarRentalContext>,IBrandDal
    {
        /*public void Add(Brand entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var addedEntity = context.Entry(entity);//referansı yakala veritabanıyla ilişkilendir 
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        */
        
    }
}
