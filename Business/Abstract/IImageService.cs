using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IImageService
    {
        IResult Add(IFormFile file, Image image);
        IResult Delete(Image image);
        IResult Update(IFormFile file, Image image);

        IDataResult<List<Image>> GetAll();
        IDataResult<List<Image>> GetByCarId(int carId);
        IDataResult<Image> GetByImageId(int imageId);
    }
}
