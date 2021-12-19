using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    class ImageManager : IImageService
    {
        IImageDal imageDal;
        IFileHelper fileHelper;

        public ImageManager(IImageDal imageDal,IFileHelper fileHelper)
        {
            this.imageDal = imageDal;
            this.fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, Image image)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(image.CarId));
            if(result!=null)
            {
                return result;
            }
            image.ImagePath = fileHelper.Upload(file, PathConstants.ImagesPath);
            image.DateTime = DateTime.Now;
            imageDal.Add(image);
            return new SuccessResult(Messages.ObjectAdded);
        }

        public IResult Delete(Image image)
        {
            fileHelper.Delete(PathConstants.ImagesPath+image.ImagePath);
            imageDal.Delete(image);
            return new SuccessResult(Messages.ObjectDeleted);
        }

        public IDataResult<List<Image>> GetAll()
        {
            return new SuccessDataResult<List<Image>>(imageDal.GetAll(), Messages.ObjectListed);
        }

        public IDataResult<List<Image>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            if(result!=null)
            {
                return new ErrorDataResult<List<Image>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<Image>>(imageDal.GetAll(i => i.CarId == carId));
        }

        public IDataResult<Image> GetByImageId(int imageId)
        {
            return new SuccessDataResult<Image>(imageDal.Get(i => i.Id == imageId),Messages.ObjecListedById);
        }

        public IResult Update(IFormFile file, Image image)
        {
            image.ImagePath = fileHelper.Update(file, PathConstants.ImagesPath + image.ImagePath, PathConstants.ImagesPath);
            imageDal.Update(image);
            return new SuccessResult(Messages.ObjectUpdated);

        }
        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = imageDal.GetAll(c => c.CarId == carId).Count;
            if(result>5)
            { return new ErrorResult(); 
            
            }
            return new SuccessResult();

        }
        private IResult CheckCarImage(int carId)
        {
            var result = imageDal.GetAll(c => c.CarId == carId).Count;
            if(result>0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
          private IDataResult<List<Image>> GetDefaultImage(int carId)
        {
           
            List<Image> image = new List<Image>();
            image.Add(new Image { CarId = carId, DateTime = DateTime.Now, ImagePath = "Defa.jpg" });
            return new SuccessDataResult<List<Image>>(image);
        }
    }
}
