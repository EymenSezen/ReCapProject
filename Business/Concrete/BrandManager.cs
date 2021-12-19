using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal ibrandDal;

        public BrandManager(IBrandDal ibrandDal)
        {
            this.ibrandDal = ibrandDal;
        }

        public IResult Add(Brand brand)
        {
            ibrandDal.Add(brand);
            return new SuccessResult(Messages.ObjectAdded);
        }

        public IResult Delete(Brand brand)
        {
            ibrandDal.Delete(brand);
            return new SuccessResult(Messages.ObjectDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(ibrandDal.GetAll(),Messages.ObjectListed);
        }


        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(ibrandDal.Get(b => b.Id == brandId), Messages.ObjecListedById);
        }

        public IResult Update(Brand brand) //normalde sadece liste veya tek bir nesne döndürürken results yapısı ile mesaj da döndürebiliyoruz......
        {
            return new SuccessResult(Messages.ObjectUpdated);
        }
    }
}
