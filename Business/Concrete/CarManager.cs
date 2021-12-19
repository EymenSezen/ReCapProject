using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal icarDal;

        public CarManager(ICarDal icarDal)
        {
            this.icarDal = icarDal;
        }

       [SecuredOperation("admin,car.add")]
       [ValidationAspect(typeof(CarValidator))]//doğruluğu kontrol et
       [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {

            ///////koşul ve işlerden sonra    //validation ve business rules
            
            IResult result = BusinessRules.Run(CheckIfDailyPriceMoreThanZero(car));
            if (result!=null)
            {

                return result;
            
            }
            icarDal.Add(car);
            return new Result(true, Messages.CarAdded);

            
        }

        public IResult Delete(Car car)
        {
            icarDal.Delete(car);
            return new SuccessResult(Messages.ObjectDeleted);
        }

       // [SecuredOperation("admin,car.add")]
        [CacheAspect]//cachee al
        [PerformanceAspect(5)]//performansı kontrol et
        [CacheRemoveAspect("ICarService.Get")]//değişiklik olursa cacheden sil
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(icarDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>( icarDal.GetAll(c => c.BrandId == id),Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(icarDal.GetAll(c => c.ColorId == id),"Renge Göre");
        }
        [CacheAspect]
        [PerformanceAspect(4)]
        [CacheRemoveAspect("ICarService.Get")]
        public IDataResult<Car> GetById(int carId)
        {
           return  new SuccessDataResult<Car>(icarDal.Get(c => c.Id == carId),Messages.ObjecListedById);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(icarDal.GetCarDetails());
        }

        public IResult Update(Car car)
        {
            icarDal.Update(car);
            return new SuccessResult(Messages.ObjectUpdated);
        }
        public IResult CheckIfDailyPriceMoreThanZero(Car car)
        {
            if (car.DailyPrice < 0)
            {
                return new ErrorResult("Günlük ödeme eksi olamaz.");
            }
            return new SuccessResult();
        }
        [TransactionScopeAspect]//Tamamla
        public IResult AddTransactional(Car car)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarDetailDto>> GetAllCarDetailsByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(icarDal.GetCarDetailsByBrandId(id), "Araçlar Markaya göre listelendi");
        }

        public IDataResult<List<CarDetailDto>> GetAllCarDetailsByColorId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(icarDal.GetCarDetailsByColorId(id), "Araçlar Renge göre listelendi");
        }

        public IDataResult<List<CarDetailPageDto>> GetCarDetailsById(int id)
        {
            return new SuccessDataResult<List<CarDetailPageDto>>(icarDal.GetCarDetailsById(id), "Araç Detayı");
        }
    }
}
