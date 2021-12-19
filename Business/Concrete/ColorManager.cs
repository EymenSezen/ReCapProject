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
    public class ColorManager : IColorService
    {
        IColorDal icolorDal;

        public ColorManager(IColorDal icolorDal)
        {
            this.icolorDal = icolorDal;
        }

        public IResult Add(Color color)
        {
            icolorDal.Add(color);
            return new SuccessResult(Messages.ObjectAdded);
        }

        public IResult Delete(Color color)
        {
            icolorDal.Delete(color);
            return new SuccessResult(Messages.ObjectDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(icolorDal.GetAll(), Messages.ObjectListed);
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(icolorDal.Get(c=>c.Id==colorId), Messages.ObjecListedById);
        }

        public IResult Update(Color color)
        {
            icolorDal.Update(color);
            return new SuccessResult(Messages.ObjectUpdated);
        }
    }
}
