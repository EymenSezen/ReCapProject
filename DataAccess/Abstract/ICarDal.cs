using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
        List<CarDetailDto> GetCarDetailsByBrandId(int id);
        List<CarDetailDto> GetCarDetailsByColorId(int id);
        List<CarDetailPageDto> GetCarDetailsById(int id);
        // GetById, GetAll, Add, Update, Delete,Get
        //GetByBrandId,GetByColorId==>işte yazdık
        //bu klasik metoflarımızın dışında o yüzden buraya yazarız 

    }
}
